using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void exit() {
        Application.Quit();
    }
    public void playGame() {
        string playerNameInput = GameObject.Find("PlayerNameInput").GetComponent<TMPro.TextMeshProUGUI>().text;
        PlayerPrefs.SetString("PlayerName", playerNameInput);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("PlayerName"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
