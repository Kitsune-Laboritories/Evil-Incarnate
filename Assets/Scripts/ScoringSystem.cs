using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int theScore = 0;
    public static Vector3 initialPosition;
    public static bool taskDone;
    public static int keys = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        taskDone = false;
    }

    void Awake()
    {
        keys = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text =  keys + " keys";
        if (keys >= 3)
        {
            taskDone = true;
        }
        
    }

}
