using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    public float offsetDistance = 30f;

    void Update()
    {
        Vector3 targetPosition = targetObject.position;
        Vector3 newPosition = targetPosition + Vector3.up * offsetDistance;
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 5f);

        if (Input.GetKeyDown(KeyCode.UpArrow) && offsetDistance >= 10f)
        {
            offsetDistance -= 5f;
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && offsetDistance <= 20f)
        {
            offsetDistance += 5f;
        }
    }
}
