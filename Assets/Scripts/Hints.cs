using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hints : MonoBehaviour
{
    public Text output1;
    public Text output2;
    public Text output3;
    public Text output4;
    public Text output5;
    public Text output6;
    private string playerName;
    public GameObject Hint;
    public static bool Paused = false;
    public GameObject H1Canvas;
    public GameObject H2Canvas;
    public GameObject H3Canvas;
    public GameObject H4Canvas;
    public GameObject H5Canvas;
    public GameObject H6Canvas;
    private int next;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        playerName = PlayerName.playerName;
        next = 0;
        output1.text = "Hint #1: ";
        output2.text = "Hint #2: ";
        output3.text = "Hint #3: ";
        output4.text = "Hint #4: ";
        output5.text = "Hint #5: ";
        output6.text = "Hint #6: ";
        ToH1Canvas();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }

        if (Hint && Input.GetKeyDown(KeyCode.Return) && next == 0)
        {
            next += 1;
            ToH2Canvas();
        }
        else if (Hint && Input.GetKeyDown(KeyCode.Return) && next == 1)
        {
            next += 1;
            ToH3Canvas();
        }
        else if (Hint && Input.GetKeyDown(KeyCode.Return) && next == 2)
        {
            next += 1;
            ToH4Canvas();
        }
        else if (Hint && Input.GetKeyDown(KeyCode.Return) && next == 3)
        {
            next += 1;
            ToH5Canvas();
        }
        else if (Hint && Input.GetKeyDown(KeyCode.Return) && next == 4)
        {
            next += 1;
            ToH6Canvas();
        }
        else if (Hint && Input.GetKeyDown(KeyCode.Return))
        {
            next = 0;
            Play();
        }
        
    }

    public void ToH1Canvas()
    {
        next = 0;
        H1Canvas.SetActive(true);
        H2Canvas.SetActive(false);
        H3Canvas.SetActive(false);
        H4Canvas.SetActive(false);
        H5Canvas.SetActive(false);
        H6Canvas.SetActive(false);
    }

    public void ToH2Canvas()
    {
        next = 1;
        H1Canvas.SetActive(false);
        H2Canvas.SetActive(true);
        H3Canvas.SetActive(false);
        H4Canvas.SetActive(false);
        H5Canvas.SetActive(false);
        H6Canvas.SetActive(false);
    }

    public void ToH3Canvas()
    {
        next = 2;
        H1Canvas.SetActive(false);
        H2Canvas.SetActive(false);
        H3Canvas.SetActive(true);
        H4Canvas.SetActive(false);
        H5Canvas.SetActive(false);
        H6Canvas.SetActive(false);
    }

    public void ToH4Canvas()
    {
        next = 3;
        H1Canvas.SetActive(false);
        H2Canvas.SetActive(false);
        H3Canvas.SetActive(false);
        H4Canvas.SetActive(true);
        H5Canvas.SetActive(false);
        H6Canvas.SetActive(false);
    }

    public void ToH5Canvas()
    {
        next = 4;
        H1Canvas.SetActive(false);
        H2Canvas.SetActive(false);
        H3Canvas.SetActive(false);
        H4Canvas.SetActive(false);
        H5Canvas.SetActive(true);
        H6Canvas.SetActive(false);
    }

    public void ToH6Canvas()
    {
        next = 5;
        H1Canvas.SetActive(false);
        H2Canvas.SetActive(false);
        H3Canvas.SetActive(false);
        H4Canvas.SetActive(false);
        H5Canvas.SetActive(false);
        H6Canvas.SetActive(true);
    }

    void Stop()
    {
        Hint.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Paused = true;

    }

    public void Play()
    {
        Hint.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        Paused = false;

    }

}
