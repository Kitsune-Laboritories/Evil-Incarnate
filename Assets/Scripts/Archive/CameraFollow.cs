using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    public float offsetDistance = 5f;
    public float rotationSpeed = 2f;
    public float minAngleY = 5f;
    public float maxAngleY = 85f;
    public float climbSpeed = 0.5f;
    private float currentAngleY = 0f; 

    void Start()
    {
        transform.position = targetObject.position - (targetObject.forward * offsetDistance) + (Vector3.up * 10);
        transform.LookAt(targetObject);
        currentAngleY = transform.eulerAngles.x;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("CameraHorizontal");
        float verticalInput = Input.GetAxis("CameraVertical");

        float angleX = horizontalInput * rotationSpeed;
        currentAngleY -= verticalInput * rotationSpeed;
        currentAngleY = Mathf.Clamp(currentAngleY, minAngleY, maxAngleY);

        Quaternion rotation = Quaternion.Euler(currentAngleY, transform.eulerAngles.y + angleX, transform.eulerAngles.z);
        Vector3 position = targetObject.position - (rotation * Vector3.forward * offsetDistance) + (Vector3.up * 10);

        transform.rotation = rotation;
        transform.position = position;
    }
}




