using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushItem : MonoBehaviour
{
    private Transform PickUpPoint;
    private Transform player;

    public float pushDistance;
    public float forceMultiplier;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("cat").transform;
        PickUpPoint = GameObject.Find("PickUpPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            forceMultiplier += 300 + Time.deltaTime;
        }

        pushDistance = Vector3.Distance(player.position, transform.position);


        if (Input.GetKeyDown(KeyCode.E))
        {

            if (pushDistance <= 1)
            {
                rb.AddForce(player.transform.forward * forceMultiplier);

                GetComponent<Rigidbody>().useGravity = true;
                //GetComponent<BoxCollider>().enabled = true;

                forceMultiplier = 0;

            }

            forceMultiplier = 0;

        }


    }
}
