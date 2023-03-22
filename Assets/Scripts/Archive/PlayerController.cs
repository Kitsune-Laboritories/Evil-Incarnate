using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 10f;
    private Camera mainCamera;
    private float jumpSpeed = 7f;
    private float gravity = 30f;
    private float verticalVelocity;
    private float friction = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        // Get the movement direction relative to the camera
        Vector3 forward = Vector3.Cross(Camera.main.transform.right, Vector3.up);
        Vector3 moveDirection = forward * Input.GetAxis("Vertical") + mainCamera.transform.right * Input.GetAxis("Horizontal");
        moveDirection.y = 0;
        moveDirection.Normalize();

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.LookRotation(forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.LookRotation(-forward);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.LookRotation(-Camera.main.transform.right);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.LookRotation(Camera.main.transform.right);
        }

        // Move the player
        if (controller.isGrounded)
        {
            verticalVelocity = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpSpeed;
            }
        }

        verticalVelocity -= gravity * Time.deltaTime;
        moveDirection.y = verticalVelocity;
        moveDirection *= speed * Time.deltaTime * friction;
        controller.Move(moveDirection * speed * Time.deltaTime);

    }
}
