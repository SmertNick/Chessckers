using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Chessckers/PlayerNames", fileName = "PlayerNames")]
public class PlayerNames : ScriptableObject
{
    [Header("Default names")]
    [SerializeField] private string playerDefaultName = "Player";
    [SerializeField] private string computerDefaultName = "Computer";

    public string PlayerDefaultName => playerDefaultName;
    public string ComputerDefaultName => computerDefaultName;

    [Header("Current names")]
    public List<string> names = new List<string>
    {
        "Player",
        "Player2"
    };

    public string GetPlayerName(int id)
    {
        CheckNames(id);

        return names[id];
    }

    public void SetPlayerName(int id, string playerName)
    {
        CheckNames(id);

        names[id] = playerName;
    }

    private void CheckNames(int id)
    {
        if (names == null)
            ResetToDefaults(id);

        if (id > names.Count - 1)
        {
            for (int i = names.Count; i <= id; i++)
            {
                names.Add(PlayerDefaultName + (i + 1));
            }
        }
    }
    
    public void ResetToDefaults(int numberOfPlayers)
    {
        List<string> newNames = new List<string>
        {
            PlayerDefaultName
        };

        for (int i = 2; i < numberOfPlayers; i++)
        {
            newNames.Add(PlayerDefaultName + i);
        }

        names = newNames;
    }
}
