using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public InputField userInput;
    public Text output;
    public static string playerName;

    public void saveName()
    {
        if(userInput.text.Length > 32)
        {
            output.text = "Name is too long!";
        }
        else
        {
            playerName = userInput.text;
            output.text = "Hello " + playerName + "! Ready to play?";
        }
        
    }

}
