using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSensitivity = 1.5f;
    public float Smoothing = 1.5f;

    private float _xMousePosition;
    private float _smoothedMousePosition;

    private float _cuurrentLookingPosition;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        GetInput();
        ModifyInput();
        RotatePlayer();
    }

    private void GetInput()
    {
        _xMousePosition = Input.GetAxisRaw("Mouse X");
    }

    private void ModifyInput()
    {
        _xMousePosition *= MouseSensitivity * Smoothing;
        _smoothedMousePosition = Mathf.Lerp(_smoothedMousePosition, _xMousePosition, 1f / Smoothing);
    }

    private void RotatePlayer()
    {
        _cuurrentLookingPosition += _smoothedMousePosition;
        transform.localRotation = Quaternion.AngleAxis(_cuurrentLookingPosition, transform.up);
    }   
}
