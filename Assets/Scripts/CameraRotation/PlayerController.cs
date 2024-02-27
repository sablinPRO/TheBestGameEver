using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float gravity = 9.8f;
    public float JumpForce;
    public float speed;

    private Vector3 _moveVector;
    private float _fallVelosity = 0;

    private CharacterController _characterController;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelosity = -JumpForce;
        }
    }

    void FixedUpdate()
    {
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        _fallVelosity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelosity * Time.fixedDeltaTime);
        if(_characterController.isGrounded)
        {
            _fallVelosity = 0;
        }
    }
}
