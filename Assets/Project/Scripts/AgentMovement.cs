using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    #region protected variables
    protected CharacterController characterController;
    protected HumanoidAnimations agentAnimations;
    protected Vector3 moveDirection = Vector3.zero;
    protected float desiredRotationAngle = 0;
    #endregion

    #region public variables
    public float MovementSpeed;
    public float Gravity;
    public float RotationSpeed;

    public int angleRotationThreshold;
    #endregion

    private int _inputVerticalDirection = 0;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        agentAnimations = GetComponent<HumanoidAnimations>();
    }
    public void HandleMovement(Vector2 input)
    {
        if (characterController.isGrounded)
        {
            if(input.y != 0)
            {
                if(input.y > 0)
                {
                    _inputVerticalDirection = Mathf.CeilToInt(input.y);
                }
                else
                {
                    _inputVerticalDirection = Mathf.FloorToInt(input.y);
                }
                moveDirection = input.y * MovementSpeed * transform.forward;
            }
            else
            {
                agentAnimations.SetMovementFloat(0);
                moveDirection = Vector3.zero;
            }
        }
    }
    public void HandleMovementDirection(Vector3 input)
    {
        desiredRotationAngle = Vector3.Angle(transform.forward, input);
        var crossProduct = Vector3.Cross(transform.forward, input).y;
        if(crossProduct < 0)
        {
            desiredRotationAngle *= -1;
        }
    }
    private void Update()
    {
        if (characterController.isGrounded)
        {
            Debug.Log(moveDirection.magnitude);
            if(moveDirection.magnitude > 0)
            {
                var animationSpeedMultiplier = agentAnimations.SetCorrectAnimation(desiredRotationAngle, angleRotationThreshold,
                    _inputVerticalDirection);
                RotateAgent();
                moveDirection *= animationSpeedMultiplier;
            }
        }
        moveDirection.y -= Gravity;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void RotateAgent()
    {
        if(desiredRotationAngle > angleRotationThreshold || desiredRotationAngle < - angleRotationThreshold)
        {
            transform.Rotate(Vector3.up * desiredRotationAngle * RotationSpeed * Time.deltaTime);
        }
    }
}
