using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Chessckers/PiecesSet", fileName = "PiecesSet")]
public class PiecesSet : ScriptableObject
{
    [Header("Chess Board")]
    [SerializeField] private GameObject board;

    [Header("Chess Piecess")]
    [SerializeField] private List<GameObject> pieces;
    
    [Header("Selection prefabs")]
    [SerializeField] private GameObject selectionYellow;
    [SerializeField] private GameObject selectionBlue;
    [SerializeField] private GameObject selectionRed;

    public GameObject Board => board;

    public List<GameObject> Pieces => pieces;

    public GameObject SelectionYellow => selectionYellow;
    public GameObject SelectionBlue => selectionBlue;
    public GameObject SelectionRed => selectionRed;
}
