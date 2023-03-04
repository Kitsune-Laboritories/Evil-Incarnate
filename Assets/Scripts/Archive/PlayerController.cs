using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody player;
    private Animator animator;
    private Quaternion direction;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        animator = GetComponent<Animator>();

        // https://docs.unity3d.com/ScriptReference/Rigidbody.MovePosition.html
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsMoving", true);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsMoving", true);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsMoving", true);

            // https://docs.unity3d.com/ScriptReference/Quaternion.AngleAxis.html
            direction = transform.rotation * Quaternion.AngleAxis(-90, Vector3.up);

            // https://stackoverflow.com/questions/69157425/basic-idea-of-quaternion-y-axis-90-degree-rotate
            player.MoveRotation(Quaternion.Lerp(transform.rotation, direction, 5f * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsMoving", true);

            // https://docs.unity3d.com/ScriptReference/Quaternion.AngleAxis.html
            direction = transform.rotation * Quaternion.AngleAxis(90, Vector3.up);

            // https://stackoverflow.com/questions/69157425/basic-idea-of-quaternion-y-axis-90-degree-rotate
            player.MoveRotation(Quaternion.Lerp(transform.rotation, direction, 5f * Time.deltaTime));
        }
        else
        {
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsIdle", true);
        }

        // https://forum.unity.com/threads/how-do-i-make-my-rigidbody-character-move-relative-to-his-rotation.983715/#post-%206395462
        move = player.rotation * move;

        player.MovePosition(transform.position + move * Time.deltaTime * 6f);


        if (Input.GetKey (KeyCode.Space))
        {
            animator.SetBool("IsMoving", true);
            player.MovePosition(transform.position + move * Time.deltaTime + Vector3.up * 8f * Time.deltaTime);
        }
    }

}
