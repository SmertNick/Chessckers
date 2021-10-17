using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
  
    [SerializeField] private PiecesSet piecesSet;
    [SerializeField] private BoardSettings boardSettings;
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
        pieces = new GameObject[boardSettings.BoardWidth, boardSettings.BoardHeight];

        SetUpPlayers(boardSettings.AmountOfPlayers);
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
