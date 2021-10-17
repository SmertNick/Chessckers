using System.Collections.Generic;
using UnityEngine;

public class Board : IBoard
{
    public event IBoard.PieceAction OnPieceAdded;

    private int[,] pieces;
    private int currentPlayerID;

    private BoardSettings boardSettings;

    private Vector2Int[] movementDirections;
    private int movementRange;
    
    private List<Vector2Int> movementPositions;

    public Board(BoardSettings boardSettings, MovementSettings movementSettings)
    {
        this.boardSettings = boardSettings;

        movementRange = movementSettings.Range;
        movementDirections = movementSettings.Directions;
        
        pieces = new int[boardSettings.BoardWidth, boardSettings.BoardHeight];
        
        movementPositions = new List<Vector2Int>();

        currentPlayerID = 1;
    }


    public void AddPiece(int playerID, int col, int row)
    {
        if (pieces[col, row] == 0)
        {
            pieces[col, row] = playerID;
        }
        OnPieceAdded?.Invoke(playerID, col, row);
    }

    public void MovePiece(Vector2Int from, Vector2Int newCell)
    {
        pieces[from.x, from.y] = 0;
        pieces[newCell.x, newCell.y] = currentPlayerID;
        NextPlayer();
    }

    private void NextPlayer()
    {
        currentPlayerID++;
        if (currentPlayerID > boardSettings.AmountOfPlayers)
        {
            currentPlayerID -= boardSettings.AmountOfPlayers;
        }
    }
    
    public bool IsValidMovement(int col, int row)
    {
        foreach (Vector2Int position in movementPositions)
        {
            if (position.x == col && position.y == row)
                return true;
        }
        
        return false;
    }

    public bool IsValidMovement(Vector2Int cell)
    {
        return IsValidMovement(cell.x, cell.y);
    }

    public bool IsCurrentOwner(int col, int row)
    {
        if (IsWithinBoard(col, row)) return pieces[col, row] == currentPlayerID;
        return false;
    }

    public List<Vector2Int> AllowedMovementPositions(int col, int row)
    {
        movementPositions.Clear();

        foreach (Vector2Int direction in movementDirections)
        {
            for (int i = 1; i <= movementRange; i++)
            {
                Vector2Int cell = new Vector2Int(col, row);
                cell += direction * i;

                if (IsWithinBoard(cell.x, cell.y) && IsEmptyCell(cell.x, cell.y))
                {
                    movementPositions.Add(cell);
                }
            }
        }
        
        return movementPositions;
    }

    private bool IsWithinBoard(int col, int row)
    {
        if (col > boardSettings.BoardWidth - 1 || col < 0 || row > boardSettings.BoardHeight - 1 || row < 0)
            return false;
        return true;
    }

    private bool IsEmptyCell(int col, int row)
    {
        return pieces[col, row] == 0;
    }
}
