using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroCity : MonoBehaviour
{
    public Text output1;
    public Text output2;
    public Text output3;
    private string playerName;
    public GameObject IntroCanvas;
    public GameObject HintCanvas;
    public GameObject HomeCanvas;
    private int next;

    // Start is called before the first frame update
    void Start()
    {
        if (playerName != null)
        {
            output1.text = "You made into the city!" + playerName + "'s house is just nearby, and will need five keys to enter.";
            output2.text = playerName + "remembers that the keys are hidden all over the city. Press H to recollect the kitty's memories to fine where the keys are hidden.";
            output3.text = "Make sure to watch for cars, you'll lose a life if you get hit! Good luck! ";
        }
        else
        {
            output1.text = "You made into the city! The kitty's house is just nearby, and will need five keys to enter.";
            output2.text = "The kitty remembers that the keys are hidden all over the city. Press H to recollect the kitty's memories to fine where the keys are hidden.";
            output3.text = "Make sure to watch for cars, you'll lose a life if you get hit! Good luck! ";
        }
        ScoringSystem.theScore = 0;
        playerName = PlayerName.playerName;
        next = 0;
        ToIntroCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Return) && next == 0)
        {
            next += 1;
            ToHintCanvas();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && next == 1)
        {
            next += 1;
            ToHomeCanvas();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.LoadScene("City");
        }
    }

    public void ToIntroCanvas()
    {
        next = 0;
        HintCanvas.SetActive(false);
        HomeCanvas.SetActive(false);
        IntroCanvas.SetActive(true);
    }

    public void ToHintCanvas()
    {
        next = 1;
        IntroCanvas.SetActive(false);
        HomeCanvas.SetActive(false);
        HintCanvas.SetActive(true);
    }

    public void ToHomeCanvas()
    {
        next = 2;
        IntroCanvas.SetActive(false);
        HintCanvas.SetActive(false);
        HomeCanvas.SetActive(true);
    }

    public void ToCityButton()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("City");
    }


}
