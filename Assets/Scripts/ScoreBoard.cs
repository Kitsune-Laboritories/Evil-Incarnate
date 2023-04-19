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
    public GameObject Next;

    // Start is called before the first frame update
    void Start()
    {
        newScore = ScoringSystem.theScore;
        playerName = PlayerName.playerName;
        GameOverCanvas.SetActive(true);
        //if (ScoringSystem.taskDone)
        //{
        //    Next.SetActive(true);
        //}
        //else
        //{
            Next.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        float timeValue = TimerCountdown.timeSpend;
        if (timeValue > 0)
        {
            int minutes = (int)timeValue / 60;
            int seconds = (int)timeValue - (60 * minutes);
            if(seconds < 10)
            {
                output.text = playerName + ": " + minutes + ":0" + seconds;
            }
            else
            {
                output.text = playerName + ": " + minutes + ":" + seconds;
            }

        }
        // output.text = playerName + ": " + timeValue;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void TryAgainButton()
    {
        SceneManager.LoadScene("Intro");
        ScoringSystem.keys = 0;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player Has Quit The Game");
    }

    public void NextScene()
    {
        //SceneManager.LoadScene("City");
    }
}
