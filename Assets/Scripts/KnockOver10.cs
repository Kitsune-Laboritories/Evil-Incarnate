using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockOver10 : MonoBehaviour
{
    private Rigidbody item;
    private bool isKnockedOver = false;
    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") > 0 && isKnockedOver == false)
        {
            Debug.Log("Item is knocked over");
            ScoringSystem.theScore += 10;
            isKnockedOver = true;
        }
        
    }
}
