using UnityEngine;

public class BoardView : MonoBehaviour, IBoardView
{
    public event IBoardView.PieceAction OnPieceMoved;
    public event IBoardView.PieceAction OnPieceSelected;

    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;
    
    private Camera cam;

    private GameObject highlight;
    private GameObject move;

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
                    OnPieceSelected?.Invoke(gameObject, hit.point);
                else
                {
                    // TODO movement logic
                }
            }
        }
        else
        {
            highlight.SetActive(false);
        }
        
    }

    public GameObject AddPiece(GameObject piece, Vector3 position)
    {
        return Instantiate(piece, position, Quaternion.identity, gameObject.transform);
    }

    public void MovePiece(GameObject piece, Vector3 newPosition)
    {
        piece.transform.position = newPosition;
        OnPieceMoved?.Invoke(piece, newPosition);
        pieceSelected = false;
    }

    public void SelectPiece(GameObject piece)
    {
        MeshRenderer renderers = piece.GetComponentInChildren<MeshRenderer>();
        renderers.material = selectedMaterial;
        pieceSelected = true;
    }
}
