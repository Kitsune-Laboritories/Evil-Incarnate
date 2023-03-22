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

    // Start is called before the first frame update
    void Start()
    {
        isKnockedOver = false;
        initialPosition = transform.position;
        taskDone = false;
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
        Debug.Log("Item is Knocked Over!");
        if (transform.position.x != initialPosition.x && transform.position.z != initialPosition.z && !taskDone)
        {
            ScoringSystem.theScore += pointsEarned;
            taskDone = true;
        }
    }
}
