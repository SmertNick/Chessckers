using UnityEngine;

public interface IBoardController
{
    void AddPiece(int playerID, int col, int row);
    void MovePiece(GameObject piece, Vector3 position);
}