using UnityEngine;

public class GeometryHelper : IGeometryHelper
{
    private int boardWidth;
    private int boardHeight;

    private float cellWidth; 
    private float cellHeight;
    
    public GeometryHelper(BoardSettings boardSettings)
    {
        boardWidth = boardSettings.BoardWidth;
        boardHeight = boardSettings.BoardHeight;

        cellWidth = boardSettings.CellWidth;
        cellHeight = boardSettings.CellHeight;
    }
    
    public Vector3 PositionFromCell(Vector2Int cell)
    {
        return PositionFromCell(cell.x, cell.y);
    }

    public Vector3 PositionFromCell(int col, int row)
    {
        float x = cellWidth * col - .5f * boardWidth + .5f * cellWidth;
        float z = cellHeight * row - .5f * boardHeight + .5f * cellHeight;
        return new Vector3(x, 0f, z);
    }
    
    public Vector2Int CellFromPosition(Vector3 position)
    {
        return CellFromPosition(position.x, position.y, position.z);
    }

    public Vector2Int CellFromPosition(float x, float y, float z)
    {
        int col = Mathf.FloorToInt(.5f * boardWidth + x / cellWidth);
        int row = Mathf.FloorToInt(.5f * boardHeight + z / cellHeight);
        return new Vector2Int(col, row);
    }
}
