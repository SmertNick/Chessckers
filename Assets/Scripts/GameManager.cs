using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
  
    [SerializeField] private PiecesSet piecesSet;
    [SerializeField] private BoardSettings boardSettings;
    [SerializeField] private PlayerNames playerNames;
    [SerializeField] private StartingPositions startingPositions;

    private List<Player> players;

    private IBoard board;
    private IBoardView boardView;
    private IBoardController boardController;
    private IGeometryHelper geometryHelper;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }

    void Start()
    {
        SetUpBoard();
        SetUpPlayers();
        SetUpPieces();
    }

    private void SetUpBoard()
    {
        geometryHelper = new GeometryHelper(boardSettings);
        boardView = Instantiate(piecesSet.Board).GetComponent<IBoardView>();
        board = new Board(boardSettings);
        boardController = new BoardController(boardSettings, piecesSet, board, boardView, geometryHelper);
    }

    private void SetUpPlayers()
    {
        players = new List<Player>();
        for (int i = 0; i < boardSettings.AmountOfPlayers; i++)
        {
            players.Add(new Player(playerNames.GetPlayerName(i)));
        }
    }

    private void SetUpPieces()
    {
        foreach (Vector3Int piece in startingPositions.Positions)
        {
            board.AddPiece(piece.x - 1, piece.y - 1, piece.z - 1);
        }
    }
}
