using UnityEngine;

public interface IBoardView
{
    public delegate void PieceAction(GameObject piece, Vector3 position);
    public event PieceAction OnPieceMoved;

    GameObject AddPiece(GameObject piece, Vector3 position);
    void MovePiece(GameObject piece, Vector3 newPosition);
    void ChangePieceMaterial(GameObject piece, Material newMaterial);
}