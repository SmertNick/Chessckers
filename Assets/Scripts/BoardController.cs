using System.Collections.Generic;
using UnityEngine;

public class BoardController : IBoardController
{
    private int boardWidth;
    private int boardHeight;

    private float cellWidth; 
    private float cellHeight;

    private IBoardView boardView;
    private IBoard board;

    private GameObject[,] pieces;
    private List<GameObject> piecesSet;

    public BoardController(BoardSettings boardSettings, PiecesSet piecesSet, IBoard board, IBoardView boardView)
    {
        boardWidth = boardSettings.BoardWidth;
        boardHeight = boardSettings.BoardHeight;

        cellWidth = boardSettings.CellWidth;
        cellHeight = boardSettings.CellHeight;

        this.board = board;
        this.boardView = boardView;

        board.OnPieceAdded += AddPiece;
        boardView.OnPieceMoved += MovePiece;

        pieces = new GameObject[boardWidth, boardHeight];
        this.piecesSet = piecesSet.Pieces;
    }

    ~BoardController()
    {
        board.OnPieceAdded -= AddPiece;
        boardView.OnPieceMoved -= MovePiece;
    }
    
    public void AddPiece(int playerID, int col, int row)
    {
        float x = cellWidth * col - .5f * boardWidth + .5f * cellWidth;
        float z = cellHeight * row - .5f * boardHeight + .5f * cellHeight;
        pieces[col, row] = boardView.AddPiece(piecesSet[playerID], new Vector3(x, 0f, z));
    }

    public void MovePiece(GameObject piece, Vector3 position)
    {
        int col = Mathf.FloorToInt(.5f * boardWidth + position.x / cellWidth);
        int row = Mathf.FloorToInt(.5f * boardHeight + position.z / cellHeight);
        
        board.MovePiece(piece, col, row);
    }
}
