using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    public float offsetDistance = 5f; 
    void Start()
    {

    }

    void Update()
    {
        transform.position = targetObject.position - (targetObject.forward * offsetDistance);
        transform.LookAt(targetObject);
	transform.rotation = targetObject.rotation;
    }
}
