using System.Collections.Generic;
using UnityEngine;

public interface IBoardView
{
    public delegate void PieceAction(GameObject piece, Vector3 position);
    public event PieceAction OnPieceMoved;
    public event PieceAction OnPieceSelected;
    
    public GameObject AddPiece(GameObject piece, Vector3 position);
    public void MovePiece(GameObject piece, Vector3 newPosition);
    public void SelectPiece(GameObject piece);
}