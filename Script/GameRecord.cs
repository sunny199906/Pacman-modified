using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameRecord : IComparable<GameRecord>
{
    public string playerName;
    public int score;

    public GameRecord(string newPlayerName, int newScore) {
        playerName = newPlayerName;
        score = newScore;
    }

    public int CompareTo(GameRecord other)
    {
        if (this.score < other.score)
        {
            return 1;
        }
        else if (this.score > other.score)
        {
            return -1;
        }
        else {
            return 0;
        }
    }

    public string getPlayerName() {
        return playerName;
    }

}
