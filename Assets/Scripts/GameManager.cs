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
    [SerializeField] private List<MovementSettings> movementSettingsList;

    public PiecesSet PiecesSet => piecesSet;
    private List<Player> players;

    private IBoard board;
    private IBoardView boardView;
    private IBoardController boardController;
    public IGeometryHelper GeometryHelper { get; private set; }

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
        GeometryHelper = new GeometryHelper(boardSettings);
        boardView = Instantiate(piecesSet.Board).GetComponent<IBoardView>();
        board = new Board(boardSettings, movementSettingsList[0]); // TODO read int from user input in UI
        boardController = new BoardController(boardSettings, piecesSet, board, boardView, GeometryHelper);

        Vector3[,] positions = new Vector3[boardSettings.BoardWidth, boardSettings.BoardHeight];
        for (int col = 0; col < boardSettings.BoardWidth; col++)
        {
            for (int row = 0; row < boardSettings.BoardHeight; row++)
            {
                positions[col, row] = GeometryHelper.PositionFromCell(col, row);
            }
        }
        boardView.SetupMovementPositions(positions);
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
            board.AddPiece(piece.x, piece.y - 1, piece.z - 1);
        }
    }
}
