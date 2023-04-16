using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockOver: MonoBehaviour
{
    public Rigidbody item;
    public float fallingThreshold = -1f;
    public int pointsEarned = 1;
    private bool isKnockedOver;
    private Vector3 initialPosition;
    private bool taskDone;
    // public AudioClip sound;
    // private GameObject m;

    // Start is called before the first frame update
    void Start()
    {
        isKnockedOver = false;
        initialPosition = transform.position;
        taskDone = false;
        // sound = (AudioClip) Resources.Load<AudioClip>("can_sound");
        // m = new GameObject("Music");
    }

    // Update is called once per frame
    void Update()
    {
        if (item.velocity.y < fallingThreshold)
        {
            isKnockedOver = true;
        }
        else
        {
            isKnockedOver = false;
        }

        if (isKnockedOver)
        {
            addScore();
        }

    }

    private void addScore()
    {
        if (transform.position.x != initialPosition.x && transform.position.z != initialPosition.z && !taskDone)
        {
            // m.AddComponent<AudioSource>();
            // m.GetComponent<AudioSource>().clip = sound;
            // m.GetComponent<AudioSource>().volume = 0.2f;
            // m.GetComponent<AudioSource>().Play();
            ScoringSystem.theScore += pointsEarned;
            taskDone = true;
        }
    }
}
