using UnityEngine;

public interface IBoard
{
    public delegate void PieceAction(int playerId, int col, int row);
    public event PieceAction OnPieceAdded;
    
    void AddPiece(int playerID, int col, int row);
    void MovePiece(GameObject piece, int col, int row);
    public bool IsCurrentOwner(int col, int row);
}