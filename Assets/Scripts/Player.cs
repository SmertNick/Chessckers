using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string Name;
    public List<GameObject> pieces;

    public Player(string name)
    {
        this.Name = name;
        pieces = new List<GameObject>();
    }
    
}

