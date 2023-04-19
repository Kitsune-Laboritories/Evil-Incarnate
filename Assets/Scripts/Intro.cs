using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public Text output1;
    public Text output2;
    public Text output3;
    private string playerName;
    public GameObject IntroCanvas;
    public GameObject KeysCanvas;
    public GameObject ControlsCanvas;
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
            output2.text = "Unfortunately the door needs three special keys to unlock. Get all three keys to unlock the door, and go home!";
            next += 1;
            ToKeysCanvas();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && next == 1)
        {
            output3.text = "Move around with the WASD key and interact with objects to find hidden treasures.";
            next += 1;
            ToStoreButton();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.LoadScene("Store");
        }
    }

    public void ToIntroCanvas()
    {
        output1.text = playerName + ", the tabby cat woke up from his nap to find his owner gone him without the poor kitty.";
        ControlsCanvas.SetActive(false);
        KeysCanvas.SetActive(false);
        IntroCanvas.SetActive(true);
    }

    public void ToKeysCanvas()
    {
        output2.text = "Unfortunately the door needs three special keys to unlock. Get all three keys to unlock the door, and go home!";
        IntroCanvas.SetActive(false);
        ControlsCanvas.SetActive(false);
        KeysCanvas.SetActive(true);
    }

    public void ToControlsCanvas()
    {
        output3.text = "Move around with the WASD key and interact with objects to find hidden treasures.";
        IntroCanvas.SetActive(false);
        KeysCanvas.SetActive(false);
        ControlsCanvas.SetActive(true);
    }

    public void ToStoreButton()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Store");
    }


}
