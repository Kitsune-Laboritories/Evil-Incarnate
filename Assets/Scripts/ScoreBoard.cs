using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    public Text output;
    private string playerName;
    public GameObject GameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        playerName = PlayerName.playerName;
        GameOverCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoringSystem.taskCity == true)
        {
            output.text = "Congratulations! You made it home!";
        }
        else
        {
            output.text = "You Died Try Again";
        }
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void TryAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player Has Quit The Game");
    }

    public void NextScene()
    {
        SceneManager.LoadScene("City");
        ScoringSystem.keys = 0;
    }
}
