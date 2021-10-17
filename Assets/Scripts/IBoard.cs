using System.Collections.Generic;
using UnityEngine;

public interface IBoard
{
    public delegate void PieceAction(int playerId, int col, int row);
    public event PieceAction OnPieceAdded;
    
    public void AddPiece(int playerID, int col, int row);
    public void MovePiece(Vector2Int from, Vector2Int newCell);
    public bool IsCurrentOwner(int col, int row);
    public bool IsValidMovement(int col, int row);
    public bool IsValidMovement(Vector2Int cell);
    public List<Vector2Int> AllowedMovementPositions(int col, int row);
}