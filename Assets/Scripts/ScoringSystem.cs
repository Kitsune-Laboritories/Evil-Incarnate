using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int theScore = 0;
    public static Vector3 initialPosition;
    public static bool taskDone;
    public static bool cityTaskDone;
    public static int keys = 0;
    public static int lives = 9;
    public TextMeshProUGUI livesText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        taskDone = false;
        cityTaskDone = false;
    }

    void Awake()
    {
        keys = 0;
        lives = 9;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text =  keys + " keys";
        livesText.text = lives + " lives";
        if (keys >= 3)
        {
            taskDone = true;
        }

        if (keys >= 5)
        {
            cityTaskDone = true;
        }

        if (lives <= 0)
        {
            SceneManager.LoadScene("ScoreBoard");
        }
    }

}
