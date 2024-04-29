using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    public AgentMovement Movement;
    public PlayerInput Input;
    public HumanoidAnimations AgentAnimations;

    #region States
    BaseState _currentState;
    #region readonly
    public readonly BaseState movementState = new MovementState();
    public readonly JumpState jumpState = new JumpState();  
    public readonly FallingState fallingState = new FallingState();
    #endregion

    #endregion
    private void Start()
    {
        Movement = GetComponent<AgentMovement>();
        Input = GetComponent<PlayerInput>();
        AgentAnimations = GetComponent<HumanoidAnimations>();
        _currentState = movementState;
        _currentState.EnterState(this);
        AssignMovementInputListeners();
    }

    private void AssignMovementInputListeners()
    {
        Input.OnJump += HandleJump;
    }

    private void HandleJump()
    {
        _currentState.HandleJumpInput();
    }

    private void OnDisable()
    {
        Input.OnJump -= _currentState.HandleJumpInput;
    }
    private void Update()
    {
        _currentState.Update();
        //Movement.HandleMovement(Input.MovementInputVector);
        //Movement.HandleMovementDirection(Input.MovementDirectionVector);
    }
    public void TransitionState(BaseState state)
    {
        _currentState = state;
        _currentState.EnterState(this);
    }
}
