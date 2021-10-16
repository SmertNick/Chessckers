using UnityEngine;

public class BoardView : MonoBehaviour, IBoardView
{
    public GameObject AddPiece(GameObject piece, Vector3 position)
    {
        return Instantiate(piece, position, Quaternion.identity, gameObject.transform);
    }

    public void MovePiece(GameObject piece, Vector3 newPosition)
    {
        piece.transform.position = newPosition;
    }

    public void ChangePieceMaterial(GameObject piece, Material newMaterial)
    {
        MeshRenderer renderers = piece.GetComponentInChildren<MeshRenderer>();
        renderers.material = newMaterial;
    }
}
