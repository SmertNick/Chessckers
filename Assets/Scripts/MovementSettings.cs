using UnityEngine;

[CreateAssetMenu(menuName = "Chessckers/MovementSettings", fileName = "MovementSettings")]
public class MovementSettings : ScriptableObject
{
    [Range(1,8)]
    [SerializeField] private int range = 1;
    [SerializeField] private Vector2Int[] directions;

    public int Range => range;
    public Vector2Int[] Directions => directions;
}
