using System.Collections.Generic;
using UnityEngine;

public class BoardController : IBoardController
{
    private IBoardView boardView;
    private IBoard board;
    private IGeometryHelper geometryHelper;

    private GameObject[,] pieces;
    private List<GameObject> piecesSet;

    private int boardWidth;
    private int boardHeight;

    public BoardController(BoardSettings boardSettings, PiecesSet piecesSet, IBoard board, IBoardView boardView, IGeometryHelper geometryHelper)
    {
        boardWidth = boardSettings.BoardWidth;
        boardHeight = boardSettings.BoardHeight;

        this.board = board;
        this.boardView = boardView;

        this.geometryHelper = geometryHelper;

        board.OnPieceAdded += AddPiece;
        boardView.OnPieceMoved += MovePiece;
        boardView.OnPieceSelected += SelectPiece;

        pieces = new GameObject[boardSettings.BoardWidth, boardSettings.BoardHeight];
        this.piecesSet = piecesSet.Pieces;
    }

    ~BoardController()
    {
        board.OnPieceAdded -= AddPiece;
        boardView.OnPieceMoved -= MovePiece;
        boardView.OnPieceSelected -= SelectPiece;
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

    public void SelectPiece(GameObject piece, Vector3 position)
    {
        Vector2Int cell = geometryHelper.CellFromPosition(position);
        boardView.SelectPiece(SelectPieceAtCell(cell));
    }
    
    private GameObject SelectPieceAtCell(int col, int row)
    {
        if (col > boardWidth - 1 || col < 0 || row > boardHeight || row < 0)
            return null;
        return pieces[col, row];
    }
    
    private GameObject SelectPieceAtCell(Vector2Int cell)
    {
        if (cell.x > boardWidth - 1 || cell.x < 0 || cell.y > boardHeight || cell.y < 0)
            return null;
        return pieces[cell.x, cell.y];
    }
}
