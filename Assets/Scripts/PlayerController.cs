using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// https://www.youtube.com/watch?v=ExEJtw2mhR4

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private float speed = 6;
    private float rotationSpeed = 90;
    private float gravity = -20f;
    private float jumpSpeed = 10;
    private float hInput;
    private float vInput;
    private Animator animator;
    Vector3 moveVelocity;
    Vector3 turnVelocity;

    void Update()
    {
        animator = GetComponent<Animator>();
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsMoving", true);
            vInput = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("IsMoving", true);
            vInput = -1f;
        }
        else
        {
            vInput = 0f;
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsIdle", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsMoving", true);
            hInput = -0.5f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("IsMoving", true);
            hInput = 0.5f;
        }
        else
        {
            hInput = 0f;
        }

        if (controller.isGrounded)
        {
            moveVelocity = transform.forward * speed * vInput;
            turnVelocity = transform.up * rotationSpeed * hInput;

            if (Input.GetKey(KeyCode.Space))
            {
                moveVelocity.y = jumpSpeed;
            }
        }
        moveVelocity.y += gravity * Time.deltaTime;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(turnVelocity * Time.deltaTime);
        }
        controller.Move(moveVelocity * Time.deltaTime);
    }
}
