using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    private Vector3 offsetDistance;

    private float angle;
    private float angle2;
    void Start()
    {
	    offsetDistance = new Vector3(0.0f, 0.0f, -10f);
	    angle = 25.0f;
	    angle2 = 0.0f;
    }
    void Update()
    {
    }

    void LateUpdate()
    {
        transform.position = targetObject.position + Quaternion.Euler(angle2, angle, 0.0f) * offsetDistance;

        if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.S)) {
            angle2 -= 40.0f * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.W)) {
            angle2 += 40.0f * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.D)) {
            angle -= 40.0f * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.A)) {
            angle += 40.0f * Time.deltaTime;
        }

    
        transform.LookAt(targetObject.position);
    }


}
