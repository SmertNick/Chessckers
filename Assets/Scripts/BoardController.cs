using System;
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
        pieces[col, row] = boardView.AddPiece(piecesSet[playerID - 1], position);
    }

    public void MovePiece(Vector3 position, GameObject piece)
    {
        Vector2Int newCell = geometryHelper.CellFromPosition(position);
        if (board.IsValidMovement(newCell))
        {
            board.MovePiece(geometryHelper.CellFromPosition(piece.transform.position), newCell);
            boardView.MovePiece(piece, geometryHelper.PositionFromCell(newCell));
        }
    }

    public void SelectPiece(Vector3 position, GameObject piece)
    {
        Vector2Int cell = geometryHelper.CellFromPosition(position);
        if (board.IsCurrentOwner(cell.x, cell.y))
        {
            GameObject selectedPiece = SelectPieceAtCell(cell);
            if (selectedPiece != null)
            {
                boardView.SelectPiece(selectedPiece);
                
                List<Vector2Int> movementCells = board.AllowedMovementPositions(cell.x, cell.y);
                boardView.ShowMovementPositions(movementCells);
            }
        }
    }
    
    private GameObject SelectPieceAtCell(int col, int row)
    {
        if (col > boardWidth - 1 || col < 0 || row > boardHeight || row < 0)
            return null;
        return pieces[col, row];
    }
    
    private GameObject SelectPieceAtCell(Vector2Int cell)
    {
        return SelectPieceAtCell(cell.x, cell.y);
    }
}
