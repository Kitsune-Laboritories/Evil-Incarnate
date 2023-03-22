// This script pushes all rigidbodies that the character touches

using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour
{
    private bool holding = false;
    public Transform rp;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "PickableObject" && Input.GetKey(KeyCode.E))
        {
            if (!holding)
            {
                // Destroy(hit.gameObject);
                hit.gameObject.SetActive(false);
                GameObject childObject = Instantiate(hit.gameObject) as GameObject;
                childObject.transform.parent = rp;
                childObject.transform.localPosition = new Vector3(0.3f, -0.2f, 0.9f);
                childObject.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                holding = true;
            }
            // if (holding)
            // {
            //     GameObject childObject = Camera.main.transform.GetChild(0).gameObject;
            //     childObject.transform.parent = null;
            //     Rigidbody childRigidbody = childObject.GetComponent<Rigidbody>();
            //     childRigidbody.isKinematic = false;
            //     childRigidbody.AddForce(Camera.main.transform.forward * 10.0f, ForceMode.Impulse);
            //     holding = false;
            // }

        }
    }
}