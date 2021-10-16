using UnityEngine;

[CreateAssetMenu(menuName = "Chessckers/PiecesSet", fileName = "PiecesSet")]
public class PiecesSet : ScriptableObject
{
    [Header("Chess Board")]
    [SerializeField] private GameObject board;

    [Header("Chess Piecess")]
    [SerializeField] private GameObject whiteBishop;
    [SerializeField] private GameObject blackBishop;
    
    [Header("Selection prefabs")]
    [SerializeField] private GameObject selectionYellow;
    [SerializeField] private GameObject selectionBlue;
    [SerializeField] private GameObject selectionRed;

    public GameObject Board => board;

    public GameObject WhiteBishop => whiteBishop;
    public GameObject BlackBishop => blackBishop;

    public GameObject SelectionYellow => selectionYellow;
    public GameObject SelectionBlue => selectionBlue;
    public GameObject SelectionRed => selectionRed;
}
