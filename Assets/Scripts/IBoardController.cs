using UnityEngine;

public interface IBoardController
{
    public void AddPiece(int playerID, int col, int row);
    public void MovePiece(Vector3 position, GameObject piece);
    public void SelectPiece(Vector3 position, GameObject piece);

}