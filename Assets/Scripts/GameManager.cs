using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
  
    [SerializeField] private PiecesSet piecesSet;
    [SerializeField] private Settings settings;
    [SerializeField] private PlayerNames playerNames;

    private GameObject[,] pieces;

    private List<Player> players;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }

    void Start()
    {
        pieces = new GameObject[settings.BoardWidth, settings.BoardHeight];

        SetUpPlayers(settings.AmountOfPlayers);
    }

    private void SetUpPlayers(int amountOfPlayers)
    {
        players = new List<Player>();
        for (int i = 0; i < amountOfPlayers; i++)
        {
            players.Add(new Player(playerNames.GetPlayerName(i)));
        }
    }
}
