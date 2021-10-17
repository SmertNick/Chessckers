using UnityEngine;

public interface IGeometryHelper
{
    Vector3 PositionFromCell(Vector2Int cell);
    Vector3 PositionFromCell(int col, int row);
    Vector2Int CellFromPosition(Vector3 position);
    Vector2Int CellFromPosition(float x, float y, float z);
}