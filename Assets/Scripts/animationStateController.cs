using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);

    }

    // Update is called once per frame
    void Update()
    {
        //if player presses wasd keyss
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("notWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("notWalking", true);
        }
    }
}
 