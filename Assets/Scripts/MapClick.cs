using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapClick : MonoBehaviour
{
    private AudioClip sound;
    private GameObject m;
    public GameObject displayMap;
    public GameObject displayMap2;
    private bool mapShow = true;

    void Start()
    {
        sound = (AudioClip) Resources.Load<AudioClip>("button");
        m = new GameObject("Music");
        displayMap.SetActive(true);
        displayMap2.SetActive(false);
    }

    public void MapButtonClickOn(){
        m.AddComponent<AudioSource>();
        m.GetComponent<AudioSource>().clip = sound;
        m.GetComponent<AudioSource>().Play();
        if (!mapShow){
            CameraFollow.offsetDistance = 500f;
            transform.position = new Vector3(25f,3f,5f);
        } else {
            CameraFollow.offsetDistance = 100f;
        }
        displayMap2.SetActive(mapShow);
        mapShow = !mapShow;
    	displayMap.SetActive(mapShow);
    }
}
