using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenKey : MonoBehaviour
{
    public GameObject HiddenObject;
    private Transform t;
    private Transform player;
    private int count;
    GameObject closestObject;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        count = 0; 
    }

    private void Awake()
    {
        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            count += 1;
            GameObject[] food = GameObject.FindGameObjectsWithTag("Food");
            float closestDistance = 1.5f;
            foreach (GameObject obj in food)
            {
                float distance = Vector3.Distance(player.position, obj.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestObject = obj;
                }
            }
        }

        if (closestObject != null && count == 3)
        {
            HiddenObject.SetActive(true);
        }
    }
}
