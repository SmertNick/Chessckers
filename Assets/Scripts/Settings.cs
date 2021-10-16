using UnityEngine;

[CreateAssetMenu(menuName = "Chessckers/GameSettings", fileName = "GameSettings")]
public class Settings : ScriptableObject
{
    [SerializeField] private Vector2Int boardSize = new Vector2Int(8, 8);
    
    [Range(1,4)]
    [SerializeField] private int amountOfPlayers = 2;

    public int BoardWidth => Mathf.Clamp(boardSize.x, 2, 64);
    public int BoardHeight => Mathf.Clamp(boardSize.y, 2, 64);

    public int AmountOfPlayers => amountOfPlayers;
}
