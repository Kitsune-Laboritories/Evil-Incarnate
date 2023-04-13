using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public InputField userInput;
    public Text output;
    public static string playerName;
    public AudioClip sound;
    private GameObject m;
    void Start()
    {
        sound = (AudioClip) Resources.Load<AudioClip>("button");
        m = new GameObject("Music");
    }

    public void saveName()
    {
        if(userInput.text.Length > 32)
        {
            output.text = "Name is too long!";
        }
        else
        {
            m.AddComponent<AudioSource>();
            m.GetComponent<AudioSource>().clip = sound;
            m.GetComponent<AudioSource>().Play();

            playerName = userInput.text;
            output.text = "Hello " + playerName + "! Ready to play?";
        }
        
    }

}
