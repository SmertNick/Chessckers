using System.Collections.Generic;
using UnityEngine;

public interface IBoardView
{
    public delegate void PieceAction(Vector3 position, GameObject piece);
    public event PieceAction OnPieceMoved;
    public event PieceAction OnPieceSelected;

    public void SetupMovementPositions(Vector3[,] positions);
    public GameObject AddPiece(GameObject piece, Vector3 position);
    public void MovePiece(GameObject piece, Vector3 newPosition);
    public void SelectPiece(GameObject piece);
    public void ShowMovementPositions(List<Vector2Int> movementPositions);
}