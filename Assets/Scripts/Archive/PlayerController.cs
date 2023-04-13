using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 25f;
    private Camera mainCamera;
    // private float jumpSpeed = 6f;
    private float gravity = 30f;
    private float verticalVelocity;
    private float friction = 0.7f;
    private bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 forward = Vector3.Cross(Camera.main.transform.right, Vector3.up);
        Vector3 moveDirection = forward * Input.GetAxis("Vertical") + mainCamera.transform.right * Input.GetAxis("Horizontal");
        moveDirection.y = 0;
        moveDirection.Normalize();

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.LookRotation(forward);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.LookRotation(-forward);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.LookRotation(-Camera.main.transform.right);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.LookRotation(Camera.main.transform.right);
        }

        if (controller.isGrounded)
        {
            verticalVelocity = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumping = true;
            }
        }

        if (jumping)
        {
            verticalVelocity = Mathf.Sqrt(2* gravity);
            jumping = false;
        }

        // Move the player
        verticalVelocity -= gravity * Time.deltaTime;
        moveDirection.y = verticalVelocity;
        moveDirection *= speed * Time.deltaTime * friction;
        controller.Move(moveDirection * speed * Time.deltaTime);

    }
}
