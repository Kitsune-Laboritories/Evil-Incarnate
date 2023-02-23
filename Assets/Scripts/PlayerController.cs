using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
	public CharacterController characterController;
	public float speed;

	void Update()
	{
		Move();
	}

	private void Move()
	{       
		if (Input.GetKey (KeyCode.LeftArrow)) {
 
            		transform.RotateAround (transform.position, Vector3.up, -40.0f* Time.deltaTime);
        	}
                if (Input.GetKey (KeyCode.RightArrow)) {
 
            		transform.RotateAround (transform.position, Vector3.up, 40.0f* Time.deltaTime);
        	}
		if (Input.GetKey (KeyCode.UpArrow)) {
 
            		transform.RotateAround (transform.position, Vector3.right, 40.0f* Time.deltaTime);
        	}
                if (Input.GetKey (KeyCode.DownArrow)) {
 
            		transform.RotateAround (transform.position, Vector3.right, -40.0f* Time.deltaTime);
        	}
                if (Input.GetKey (KeyCode.W)) {
 
            		transform.position = transform.position + transform.forward * speed * Time.deltaTime;
        	}
		if (Input.GetKey (KeyCode.S)) {
 
            		transform.position = transform.position + transform.forward * -speed * Time.deltaTime;
        	}
                if (Input.GetKey (KeyCode.A)) {
 
            		transform.position = transform.position + transform.right * -speed * Time.deltaTime;
        	}
                if (Input.GetKey (KeyCode.D)) {
 
            		transform.position = transform.position + transform.right * speed * Time.deltaTime;
        	}
                
		
	}
}