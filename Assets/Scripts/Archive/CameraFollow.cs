using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    public static float offsetDistance = 100f;

    void Update()
    {
        Vector3 targetPosition = targetObject.position;
        Vector3 newPosition = targetPosition + Vector3.up * offsetDistance;
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 5f);
    }
}
