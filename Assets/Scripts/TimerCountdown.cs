using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerCountdown : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public static float timeValue = 360;
    

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            int minutes = (int)timeValue / 60;
            int seconds = (int)timeValue - (60 * minutes);
            if(seconds < 10)
            {
                timeText.text = minutes + ":0" + seconds;
            }
            else
            {
                timeText.text = minutes + ":" + seconds;
            }
            
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("ScoreBoard");
        }

    }
    
}
