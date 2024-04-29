using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MovementInputVector { get; private set; }
    public Vector3 MovementDirectionVector { get; private set; }

    private Camera _mainCamera;

    public Action OnJump { get; set; }
    private void Start()
    {
        _mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        GetMovementInput();
        GetMovementDirection();
        GetJumpInput();
    }
    private void GetJumpInput()
    {
        if(Input.GetAxisRaw("Jump") > 0)
        {
            OnJump?.Invoke();
        }
    }
    private void GetMovementDirection()
    {
        MovementInputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void GetMovementInput()
    {
        var cameraForwardDirection = _mainCamera.transform.forward;
        MovementDirectionVector = Vector3.Scale(cameraForwardDirection, (Vector3.right + Vector3.forward));
    }
}
