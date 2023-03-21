using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockOver: MonoBehaviour
{
    public Rigidbody item;
    public float fallingThreshold = -1f;
    public int pointsEarned = 1;
    private bool isKnockedOver;

    // Start is called before the first frame update
    void Start()
    {
        isKnockedOver = false;
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
        ScoringSystem.theScore += pointsEarned;
    }
}
