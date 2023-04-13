using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    public Text output;
    private int newScore;
    private string playerName;
    public GameObject GameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        newScore = ScoringSystem.theScore;
        playerName = PlayerName.playerName;
        GameOverCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        output.text = playerName + ": " + newScore;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void TryAgainButton()
    {
        SceneManager.LoadScene("Intro");
        ScoringSystem.theScore = 0;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player Has Quit The Game");
    }
}
