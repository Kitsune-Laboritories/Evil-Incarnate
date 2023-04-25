using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

   // public static Vector3 initialPosition;
    public static bool taskStore;
    public static bool taskCity;
    public static int keys;
    public static int lives = 9;
    public TextMeshProUGUI livesText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        taskStore = false;
        taskCity = false;
    }

    void Awake()
    {
        keys = 0;
        lives = 9;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = keys + " keys";
        livesText.text = lives + " lives";
        if (keys >= 3)
        {
            taskStore = true;
            Debug.Log("Task in the the Store done?: " + taskStore);
        }

        if (keys >= 5)
        {
            taskCity = true;
        }

        if (lives <= 0)
        {
            SceneManager.LoadScene("ScoreBoard");
        }
    }

}
