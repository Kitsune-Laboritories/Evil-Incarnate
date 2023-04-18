using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    
    private GameObject key;
    private Transform t;
    private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
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
                key = closestObject;
                ScoringSystem.keys += 1;
                Destroy(key);
                
            }
        }



    }
}
