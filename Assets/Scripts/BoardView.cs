using System.Collections.Generic;
using UnityEngine;

public class BoardView : MonoBehaviour, IBoardView
{
    public event IBoardView.PieceAction OnPieceMoved;
    public event IBoardView.PieceAction OnPieceSelected;

    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;
    
    private Camera cam;

    private GameObject highlight;
    private GameObject[,] movements;

    private GameObject selectedPiece;

    // TODO Make a proper state machine
    private bool pieceSelected;
    
    private IGeometryHelper geometryHelper;

    void Start()
    {
        cam = Camera.main;
        highlight = Instantiate(GameManager.instance.PiecesSet.SelectionYellow);
        geometryHelper = GameManager.instance.GeometryHelper;
        pieceSelected = false;
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector2Int cell = geometryHelper.CellFromPosition(hit.point);

            highlight.transform.position = geometryHelper.PositionFromCell(cell);
            highlight.SetActive(true);
            
            if (Input.GetMouseButtonDown(0))
            {
                if (!pieceSelected)
                    OnPieceSelected?.Invoke(hit.point, selectedPiece);
                else
                {
                    // TODO movement logic
                    OnPieceMoved?.Invoke (hit.point, selectedPiece);
                }
            }
        }
        else
        {
            highlight.SetActive(false);
        }
        
    }

    public void SetupMovementPositions(Vector3[,] positions)
    {
        movements = new GameObject[positions.GetLength(0), positions.GetLength(1)];
        for (int col = 0; col < positions.GetLength(0); col++)
        {
            for (int row = 0; row < positions.GetLength(1); row++)
            {
                movements[col, row] = Instantiate(GameManager.instance.PiecesSet.SelectionBlue,
                    positions[col, row], Quaternion.identity, gameObject.transform);
                movements[col, row].SetActive(false);
            }
        }
    }

    public GameObject AddPiece(GameObject piece, Vector3 position)
    {
        return Instantiate(piece, position, Quaternion.identity, gameObject.transform);
    }

    public void MovePiece(GameObject piece, Vector3 newPosition)
    {
        piece.transform.position = newPosition;
        
        DeselectPiece(piece);
        ClearMovementTiles();
    }

    private void ClearMovementTiles()
    {
        for (int col = 0; col < movements.GetLength(0); col++)
        {
            for (int row = 0; row < movements.GetLength(1); row++)
            {
                movements[col, row].SetActive(false);
            }
        }
    }

    public void SelectPiece(GameObject piece)
    {
        MeshRenderer renderers = piece.GetComponentInChildren<MeshRenderer>();
        renderers.material = selectedMaterial;
        selectedPiece = piece;
        pieceSelected = true;
    }

    private void DeselectPiece(GameObject piece)
    {
        MeshRenderer renderers = piece.GetComponentInChildren<MeshRenderer>();
        renderers.material = defaultMaterial;
        selectedPiece = null;
        pieceSelected = false;
    }

    public void ShowMovementPositions(List<Vector2Int> movementPositions)
    {
        foreach (Vector2Int position in movementPositions)
        {
            movements[position.x, position.y].SetActive(true);
        }
    }
}
