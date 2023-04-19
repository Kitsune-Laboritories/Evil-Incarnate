using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    
    private GameObject key;
    // private Transform t;
    private Transform player;
    private AudioClip key_sound;
    private GameObject m;
    
    // Start is called before the first frame update
    void Start()
    {
        ScoringSystem.keys = 0;
    }

    private void Awake()
    {
        // t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        key_sound = (AudioClip) Resources.Load<AudioClip>("getKey");
        m = new GameObject("Music");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject[] keys = GameObject.FindGameObjectsWithTag("Key");
            float closestDistance = 1.0f;
            GameObject closestObject = null;
            foreach (GameObject obj in keys)
            {
                float distance = Vector3.Distance(player.position, obj.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestObject = obj;
                }
            }


            if (closestObject != null)
            {
                m.AddComponent<AudioSource>();
                m.GetComponent<AudioSource>().clip = key_sound;
                m.GetComponent<AudioSource>().volume = 0.3f;
                m.GetComponent<AudioSource>().Play();
                key = closestObject;
                ScoringSystem.keys += 1;
                Destroy(key);
                
            }
        }



    }
}
