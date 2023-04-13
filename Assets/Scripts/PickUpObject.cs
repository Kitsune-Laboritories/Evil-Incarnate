using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private bool holding = false;
    public Transform rp;
    private GameObject pickedObject;

    void Update()
    {
        if (Input.GetKey(KeyCode.E) && !holding)
        {
            float maxDistance = 2.0f;

            GameObject[] pickableObjects = GameObject.FindGameObjectsWithTag("PickableObject");

            float closestDistance = float.MaxValue;
            GameObject closestObject = null;
            foreach (GameObject obj in pickableObjects)
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
                pickedObject = closestObject;
                Destroy(pickedObject);
                Rigidbody pickedObj = pickedObject.GetComponent<Rigidbody>();
                pickedObj.useGravity = false;
                GameObject childObject = Instantiate(pickedObject) as GameObject;
                childObject.transform.parent = rp;
                childObject.transform.localPosition = new Vector3(0f, 0.1f, 0f);
                childObject.transform.position = transform.position + transform.forward * 0.3f + transform.up * 0.2f;
                childObject.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                holding = true;
            }
        }

        if (Input.GetKey(KeyCode.Q) && holding)
        {
            GameObject childObject = rp.GetChild(0).gameObject;
            childObject.transform.parent = null;
            Rigidbody childRigidbody = childObject.GetComponent<Rigidbody>();
            childRigidbody.isKinematic = false;
            childRigidbody.useGravity = true;
            childRigidbody.AddForce(rp.forward * 5.0f, ForceMode.Impulse);
            holding = false;
        }
    }
}
