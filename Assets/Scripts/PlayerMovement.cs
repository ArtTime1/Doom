using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _playerSpeed = 20f;
    private CharacterController _characterController;
    private Vector3 _inputVector;
    private Vector3 _movementVector;
    private float _gravity = -9.81f;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        GetInput();
        Movement();
    }

    private void GetInput()
    {
        _inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f , Input.GetAxisRaw("Vertical"));
        _inputVector.Normalize();
        _inputVector = transform.TransformDirection(_inputVector);

        _movementVector = (_inputVector * _playerSpeed) + (Vector3.up * _gravity);
    }

    private void Movement()
    {
        _characterController.Move(_movementVector * Time.deltaTime);
    }
}
