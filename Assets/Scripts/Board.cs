using UnityEngine;

public class Board : IBoard
{
    public event IBoard.PieceAction OnPieceAdded;

    private int[,] pieces;

    private int currentPlayerID;
    

    public Board(BoardSettings boardSettings)
    {
        pieces = new int[boardSettings.BoardWidth, boardSettings.BoardHeight];
    }


    public void AddPiece(int playerID, int col, int row)
    {
        if (pieces[col, row] == 0)
        {
            pieces[col, row] = playerID + 1;
        }
        OnPieceAdded?.Invoke(playerID, col, row);
        //player.pieces.Add(pieceObject);
        //pieces[col, row] = pieceObject;
    }

    public void MovePiece(GameObject piece, int col, int row)
    {
        
    }

    public bool isCurrentOwner(int col, int row)
    {
        return false;
    }
    
}
