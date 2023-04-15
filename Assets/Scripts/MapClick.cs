using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapClick : MonoBehaviour
{
    private AudioClip sound;
    private GameObject m;
    public GameObject displayMap;
    public GameObject displayMap2;
    private bool mapShow;

    void Start()
    {
        sound = (AudioClip) Resources.Load<AudioClip>("button");
        m = new GameObject("Music");
        displayMap.SetActive(false);
        displayMap2.SetActive(true);
    }

    public void MapButtonClickOn(){
        m.AddComponent<AudioSource>();
        m.GetComponent<AudioSource>().clip = sound;
        m.GetComponent<AudioSource>().Play();
        displayMap2.SetActive(mapShow);
        mapShow = !mapShow;
    	displayMap.SetActive(mapShow);
    }
}
