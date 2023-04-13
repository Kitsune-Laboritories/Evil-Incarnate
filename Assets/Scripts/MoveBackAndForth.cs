using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 10f;
    private Vector3 initialPos;
    private bool movingForward = true;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingForward)
        {
            if (Vector3.Distance(transform.position, initialPos) < distance)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else
            {
                movingForward = false;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, initialPos) >= 5f)
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            else
            {
                movingForward = true;
            }
        }
    }
}
