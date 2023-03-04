using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatController : MonoBehaviour
{
    public float speed;
    private Vector2 move;
    Animator animator;
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        //if joystick is pressed player is walking
        if (move.x != 0)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("notWalking", false);
            Debug.Log(move.x + " and " + move.y + "Cat Walks");
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("notWalking", true);
        }
    }

    public void movePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}