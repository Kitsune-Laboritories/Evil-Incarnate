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
    public AudioClip sound;
    private GameObject m;

    // Start is called before the first frame update
    void Start()
    {
        playerName = PlayerName.playerName;
        GameOverCanvas.SetActive(true);
        sound = (AudioClip) Resources.Load<AudioClip>("button");
        m = new GameObject("Music");
        m.AddComponent<AudioSource>();
        m.GetComponent<AudioSource>().clip = sound;
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
        m.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void TryAgainButton()
    {
        m.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        m.GetComponent<AudioSource>().Play();
        Application.Quit();
        Debug.Log("Player Has Quit The Game");
    }

    public void NextScene()
    {
        m.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("City");
        ScoringSystem.keys = 0;
    }
}
