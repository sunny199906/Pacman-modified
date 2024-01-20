using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameData newGameData;
    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;
    public Transform pickups;
    public Transform accelarators;
    public GameObject ScoreDisplay;
    public GameObject LifeDisplay;
    public GameObject EndGameMenu;

    public int ghostMultiplier { get; private set; } = 1;
    public int score { get; private set; }
    public int lives { get; private set; }

    private void Start()
    {
        
        SetEndGameMenu();
        NewGame();
    }

    private void Update()
    {
        if (this.lives <= 0 && Input.anyKeyDown) {
            NewGame();
        }
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Saving Data b4 close");
        SaveGameManager.SaveGameData(GameDataController.singGameData.currentGameData);
    }

    private void NewGame() {
        SetScore(100);
        SetLives(3);
        NewRound();
    }

    private void SetEndGameMenu() {
        EndGameMenu = GameObject.Find("EndGame Canvas");
        EndGameMenu.SetActive(false);
    }

    private void NewRound() 
    {
        foreach (Transform pellet in this.pellets) {
            pellet.gameObject.SetActive(true);
        }
        foreach (Transform pickup in this.pickups)
        {
            pickup.gameObject.SetActive(true);
        }
        foreach (Transform accelarator in this.accelarators)
        {
            accelarators.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        ResetGhostMultiplier();

        for (int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].ResetState();
        }

        this.pacman.ResetState();
    }

    private void GameOver() {
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }

        this.pacman.gameObject.SetActive(false);
        EndGameMenu.SetActive(true);
        GameObject.Find("End Score").GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
        GameDataController.singGameData.currentGameData.addGameRecord(PlayerPrefs.GetString("PlayerName"), score);

        SaveGameManager.SaveGameData(GameDataController.singGameData.currentGameData);

    }

    private void SetScore(int score) {
        this.score = score;
        ScoreDisplay.GetComponent<TMPro.TextMeshPro>().text = "Score: "+score.ToString();
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        LifeDisplay.GetComponent<TMPro.TextMeshPro>().text = "Lives: " + lives.ToString();
    }

    public void GhoatEaten(Ghost ghost) {
        SetScore(this.score + ghost.points * this.ghostMultiplier);
        this.ghostMultiplier++;
    }

    public void PacmanEaten()
    {
        this.pacman.gameObject.SetActive(false);
        SetLives(this.lives-1);

        if (this.lives > 0)
        {
            Invoke(nameof(ResetState), 3.0f);
        } else {
            GameOver();
        }
    }

    public void PelletEaten(Pellet pellet) 
    {
        pellet.gameObject.SetActive(false);
        SetScore(this.score + pellet.point);
        if (this.pacman.movement.speedMultiplier > 0.02f) {
            this.pacman.movement.speedMultiplier -= 0.02f;
        }
        

        if (!HasRemainingPellets()) {
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }
    }

    public void PowerPelletEaten(PowerPellet pellet) 
    {
        for (int i=0; i<this.ghosts.Length; i++) {
            this.ghosts[i].frightened.Enable(pellet.duration);
        }

        PelletEaten(pellet);
        CancelInvoke();
        Invoke(nameof(ResetGhostMultiplier), pellet.duration);
        //
    }

    public void ClockEaten(Clock clock)
    {
        clock.gameObject.SetActive(false);
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].movement.speedMultiplier = 0;
        }
        Invoke(nameof(ResetGhostSpeedMultiplier), clock.duration);
    }

    public void WalkOnAccelarator(Accelarator accelarator) {
        this.pacman.movement.accelate = 2f;
        Invoke(nameof(SlowDownAfterAccelarate), accelarator.duration);
    }

    private bool HasRemainingPellets() {
        foreach (Transform pellet in this.pellets)
        {
            if (pellet.gameObject.activeSelf)
                return true;
        }
        return false;
    }

    public void SlowDownAfterAccelarate() {
        this.pacman.movement.accelate = 1f;
    }

    public void ResetPacmanSpeedMultiplier()
    {
        this.pacman.movement.speedMultiplier = 1f;
    }
    private void ResetGhostSpeedMultiplier()
    {
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].movement.speedMultiplier = 1;
        }
    }

    private void ResetGhostMultiplier() {
        this.ghostMultiplier = 1;
    }

    private bool checkHighestScore() {
        List<GameRecord> leaderBoard = GameDataController.singGameData.currentGameData.getAllRecord();
        foreach (GameRecord gameRecord in leaderBoard) {
            if (score>gameRecord.score) {
                return true;
            } 
        }
        return false;
    }

}
