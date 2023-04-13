using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatObject : MonoBehaviour
{
    private GameObject food;
    private AudioClip key_sound;
    private AudioClip eat_sound;
    private GameObject m;
    // Start is called before the first frame update
    void Start()
    {
        key_sound = (AudioClip) Resources.Load<AudioClip>("getKey");
        eat_sound = (AudioClip) Resources.Load<AudioClip>("eat");
        m = new GameObject("Music");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float maxDistance = 10.0f;

            GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");

            float closestDistance = float.MaxValue;
            GameObject closestObject = null;
            foreach (GameObject obj in foods)
            {
                float distance = Vector3.Distance(transform.position, obj.transform.position);
                if (distance < closestDistance && distance < maxDistance)
                {
                    closestDistance = distance;
                    closestObject = obj;
                }
            }

            if (closestObject != null)
            {
                m.AddComponent<AudioSource>();
                m.GetComponent<AudioSource>().clip = eat_sound;
                m.GetComponent<AudioSource>().volume = 0.2f;
                m.GetComponent<AudioSource>().Play();
                Destroy(closestObject);
                ScoringSystem.theScore += 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            float maxDistance = 10.0f;

            GameObject[] keys = GameObject.FindGameObjectsWithTag("Key");

            float closestDistance = float.MaxValue;
            GameObject closestObject = null;
            foreach (GameObject obj in keys)
            {
                float distance = Vector3.Distance(transform.position, obj.transform.position);
                if (distance < closestDistance && distance < maxDistance)
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
                Destroy(closestObject);
                ScoringSystem.keys += 1;
            }
        }
    }


}
