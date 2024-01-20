using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public void backToHome()
    {
        GameRecord leaderboardRecord = GameDataController.singGameData.currentGameData.getOneRecord(0);
        Debug.Log("Test"+ leaderboardRecord.getPlayerName());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
