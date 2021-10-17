using UnityEngine;

[CreateAssetMenu(menuName = "Chessckers/StartingPositions", fileName = "StartingPositions")]
public class StartingPositions : ScriptableObject
{
    [Header("X - playerID (1 or 2). Y - Column, Z - Row")]
    [SerializeField] private Vector3Int[] positions;

    public Vector3Int[] Positions => positions;
}
