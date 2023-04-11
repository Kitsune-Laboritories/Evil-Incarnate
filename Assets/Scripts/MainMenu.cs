using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip sound;
    private GameObject m;
    void Start()
    {
        sound = (AudioClip) Resources.Load<AudioClip>("button");
        m = new GameObject("Music");
    }
    public void Play()
    {
        m.AddComponent<AudioSource>();
        m.GetComponent<AudioSource>().clip = sound;
        m.GetComponent<AudioSource>().Play();

        SceneManager.LoadScene("Store");
    }

    public void Quit()
    {
        m.AddComponent<AudioSource>();
        m.GetComponent<AudioSource>().clip = sound;
        m.GetComponent<AudioSource>().Play();

        Application.Quit();
        Debug.Log("Player Has Quit The Game");
    }

}
