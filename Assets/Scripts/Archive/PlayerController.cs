using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody player;
    private float speed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // https://docs.unity3d.com/ScriptReference/Rigidbody.MovePosition.html
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 forward = Vector3.Cross(Camera.main.transform.right, Vector3.up);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Move the player forward
            player.MovePosition(transform.position + forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.LookRotation(forward);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // Move the player backward
            player.MovePosition(transform.position - forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.LookRotation(-forward);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Move the player to the left
            player.MovePosition(transform.position - Camera.main.transform.right * Time.deltaTime * speed);
            transform.rotation = Quaternion.LookRotation(-Camera.main.transform.right);

        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // Move the player to the right
            player.MovePosition(transform.position + Camera.main.transform.right * Time.deltaTime * speed);
            transform.rotation = Quaternion.LookRotation(Camera.main.transform.right);
        }

        if (Input.GetKey (KeyCode.Space))
        {
            player.MovePosition(transform.position + move * Time.deltaTime + Vector3.up * 5f * Time.deltaTime);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody obj = hit.collider.attachedRigidbody;

        if (obj != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            obj.AddForceAtPosition(forceDirection * 1f, transform.position, ForceMode.Impulse);
        }
    }

}
