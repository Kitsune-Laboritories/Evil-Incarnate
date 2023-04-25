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
            output2.text = "You made into the city!" + playerName + "'s house is just nearby, and will need five keys to enter.";
            next += 1;
            ToHintCanvas();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && next == 1)
        {
            output3.text = "Move around with the WASD key and interact with objects to find hidden treasures.";
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
        output1.text = "You made into the city!" + playerName + "'s house is just nearby, and will need five keys to enter.";
        HintCanvas.SetActive(false);
        HomeCanvas.SetActive(false);
        IntroCanvas.SetActive(true);
    }

    public void ToHintCanvas()
    {
        if (playerName != null)
        {
            output2.text = playerName + "remembers that the keys are hidden all over the city, press H to recollect where they are hidden.";
        }
        else
        {
            output2.text = "The kitty remembers that the keys are hidden all over the city, press H to recall where they are hidden.";
        }
        IntroCanvas.SetActive(false);
        HomeCanvas.SetActive(false);
        HintCanvas.SetActive(true);
    }

    public void ToHomeCanvas()
    {
        output3.text = "Find all five keys and find your way home. Good luck!";
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
