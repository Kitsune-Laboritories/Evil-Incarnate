using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class CatController : MonoBehaviour
{
   
    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;
    [SerializeField] private float speed;

    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float _velocity;

    [SerializeField] private float jumpPower;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ApplyGravity();
        ApplyRotation();
        movePlayer();
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        //Debug.Log("Player moving!" + _input);
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    public void ApplyGravity()
    {
        if (IsGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime; 
        }
        
        _direction.y = _velocity;
    }

    private void ApplyRotation()
    {
        if(_input.sqrMagnitude == 0) return;

        //rotates character to direction of movement
        var targetAngle = Mathf.Atan2(_direction.x, _direction.y);

        Vector3 movement = new Vector3(_input.x, 0.0f, _input.y);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 1f);
    }

    public void movePlayer()
    { 
        //moves character
        _characterController.Move(_direction* speed * Time.deltaTime);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGrounded()) return;

        _velocity += jumpPower;
    }

    private bool IsGrounded() => _characterController.isGrounded;
    
}