using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<GameRecord> leaderBoard = new List<GameRecord>();
    public List<Achievement> achievementList = new List<Achievement>();

    public GameData() {
        initAchievement();
    }

    public void addGameRecord(string playername, int score) {
        leaderBoard.Add(new GameRecord(playername, score));
        leaderBoard.Sort();
        Debug.Log("Size: "+leaderBoard.Count);
    }

    public GameRecord getOneRecord(int index) {
        return leaderBoard[index];
    }

    public List<GameRecord> getAllRecord() {
        return leaderBoard;
    }

    public void initAchievement() {
        achievementList.Add(new Achievement("Highest Score on Board!!"));
    }
    
}
