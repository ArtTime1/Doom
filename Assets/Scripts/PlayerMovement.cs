using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement _playerMovement;
    
    [SerializeField] private float _playerSpeed = 20f;
    [SerializeField] private float _momentumDamping = 5f;
    private CharacterController _characterController;
    
    private Vector3 _inputVector;
    private Vector3 _movementVector;
    private float _gravity = -9.81f;

    [SerializeField] private Animator _camAnimator;
    private bool isWalking;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerMovement = this;
    }

    
    void Update()
    {
        GetInput();
        Movement();
        CameraAnimation();
    }

    private void GetInput()
    {
       if(Input.GetKey(KeyCode.W) ||
          Input.GetKey(KeyCode.A) ||
          Input.GetKey(KeyCode.S) ||
          Input.GetKey(KeyCode.D))
        {
            _inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            _inputVector.Normalize();
            _inputVector = transform.TransformDirection(_inputVector);

            isWalking = true;
        }
        else
        {
            _inputVector = Vector3.Lerp(_inputVector, Vector3.zero, _momentumDamping * Time.deltaTime);

            isWalking = false;
        }

        _movementVector = (_inputVector * _playerSpeed) + (Vector3.up * _gravity);
    }

    private void Movement()
    {
        _characterController.Move(_movementVector * Time.deltaTime);
    }

    private void CameraAnimation()
    {
        _camAnimator.SetBool("isWalking", isWalking);       
    }
}
