using System.Collections.Generic;
using UnityEngine;

public class BoardController : IBoardController
{
    private IBoardView boardView;
    private IBoard board;
    private IGeometryHelper geometryHelper;

    private GameObject[,] pieces;
    private List<GameObject> piecesSet;

    public BoardController(BoardSettings boardSettings, PiecesSet piecesSet, IBoard board, IBoardView boardView, IGeometryHelper geometryHelper)
    {
        this.board = board;
        this.boardView = boardView;

        board.OnPieceAdded += AddPiece;
        boardView.OnPieceMoved += MovePiece;

        pieces = new GameObject[boardSettings.BoardWidth, boardSettings.BoardHeight];
        this.piecesSet = piecesSet.Pieces;
    }

    ~BoardController()
    {
        board.OnPieceAdded -= AddPiece;
        boardView.OnPieceMoved -= MovePiece;
    }
    
    public void AddPiece(int playerID, int col, int row)
    {
        Vector3 position = geometryHelper.PositionFromCell(col, row);
        pieces[col, row] = boardView.AddPiece(piecesSet[playerID], position);
    }

    public void MovePiece(GameObject piece, Vector3 position)
    {
        Vector2Int cell = geometryHelper.CellFromPosition(position);
        board.MovePiece(piece, cell.x, cell.y);
    }
}
