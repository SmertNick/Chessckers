using UnityEngine;

public interface IBoardView
{
    GameObject AddPiece(GameObject piece, Vector3 position);
    void MovePiece(GameObject piece, Vector3 newPosition);
    void ChangePieceMaterial(GameObject piece, Material newMaterial);
}