using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerCountdown : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float timeValue = 90;
    

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
                timeText.text = minutes + ":0" + seconds + " Left";
            }
            else
            {
                timeText.text = minutes + ":" + seconds + " Left";
            }
            
        }
        else
        {
            timeText.text = "Times up!";
        }

    }
    
}
