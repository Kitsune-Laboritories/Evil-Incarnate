using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public Text output;
    private string playerName;
    public GameObject IntroCanvas;

    // Start is called before the first frame update
    void Start()
    {
        ScoringSystem.theScore = 0;
        playerName = PlayerName.playerName;

    }

    // Update is called once per frame
    void Update()
    {
        output.text = playerName + ", the tabby cat woke up from his nap to find his owner gone without a proper goodbye kiss. Mess up the store to show him whats what." ;
    }

    public void XButton()
    {
        SceneManager.LoadScene("Store");
    }


}
