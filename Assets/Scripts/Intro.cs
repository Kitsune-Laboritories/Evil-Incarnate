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
    public AudioClip sound;
    private GameObject m;
    private bool introStart;

    // Start is called before the first frame update
    void Start()
    {
        playerName = PlayerName.playerName;
        next = 0;
        sound = (AudioClip) Resources.Load<AudioClip>("button");
        m = new GameObject("Music");
        m.AddComponent<AudioSource>();
        m.GetComponent<AudioSource>().clip = sound;
        introStart = true;
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
        if(!introStart)
        {
            m.GetComponent<AudioSource>().Play();
            introStart = false;
        }
        output1.text = playerName + ", the tabby cat woke up from his nap to find his owner gone him without the poor kitty.";
        ControlsCanvas.SetActive(false);
        KeysCanvas.SetActive(false);
        IntroCanvas.SetActive(true);
    }

    public void ToKeysCanvas()
    {
        m.GetComponent<AudioSource>().Play();
        introStart = false;
        output2.text = "Unfortunately the door needs three special keys to unlock. Get all three keys to unlock the door, and go home!";
        IntroCanvas.SetActive(false);
        ControlsCanvas.SetActive(false);
        KeysCanvas.SetActive(true);
    }

    public void ToControlsCanvas()
    {
        m.GetComponent<AudioSource>().Play();
        introStart = false;
        output3.text = "Move around with the WASD key and interact with objects to find hidden treasures.";
        IntroCanvas.SetActive(false);
        KeysCanvas.SetActive(false);
        ControlsCanvas.SetActive(true);
    }

    public void ToStoreButton()
    {
        m.GetComponent<AudioSource>().Play();
        introStart = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Store");
    }


}
