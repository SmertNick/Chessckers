using UnityEngine;

[CreateAssetMenu(menuName = "Chessckers/GameSettings", fileName = "GameSettings")]
public class BoardSettings : ScriptableObject
{
    [SerializeField] private Vector2Int boardSize = new Vector2Int(8, 8);
    [SerializeField] private Vector2 cellSize = new Vector2(1f, 1f);
    
    [SerializeField] private int amountOfPlayers = 2;

    public Vector2Int BoardSize => boardSize;
    public int BoardWidth => boardSize.x;
    public int BoardHeight => boardSize.y;

    public Vector2 CellSize => cellSize;
    public float CellWidth => cellSize.x;
    public float CellHeight => cellSize.y;

    public int AmountOfPlayers => amountOfPlayers;
}
