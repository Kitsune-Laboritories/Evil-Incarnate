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
        
        if (Input.GetAxis("Horizontal") != 0)
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
 