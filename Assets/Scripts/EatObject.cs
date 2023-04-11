using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatObject : MonoBehaviour
{
    private GameObject food;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float maxDistance = 2.0f;

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
                Destroy(closestObject);
                ScoringSystem.theScore += 1;
            }
        }
    }


}
