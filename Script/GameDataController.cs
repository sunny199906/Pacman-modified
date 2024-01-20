using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameDataController : MonoBehaviour
{
    public static GameDataController singGameData;

    public GameData currentGameData;
    void Awake()
    {
        if (singGameData != null)
            //GameObject.Destroy(singGameData);
            Destroy(gameObject);
        else
        {
            GameData readSavedData = SaveGameManager.ReadGameData();
            if (readSavedData != null)
            {
                this.currentGameData = readSavedData;
                singGameData = this;
                Debug.Log(singGameData.currentGameData.leaderBoard[0].getPlayerName());
            }
            else 
            {
                this.currentGameData = new GameData();
                singGameData = this;
                Debug.Log("New game data");
            }
            
        }
            

        DontDestroyOnLoad(this);
    }

    
}
