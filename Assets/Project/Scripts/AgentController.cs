using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    public AgentMovement Movement;
    public PlayerInput Input;
    public HumanoidAnimations AgentAnimations;

    public InventorySystem InventorySystem;

    #region States
    BaseState _currentState;
    #region readonly
    public readonly BaseState movementState = new MovementState();
    public readonly JumpState jumpState = new JumpState();  
    public readonly FallingState fallingState = new FallingState();
    public readonly InventoryState inventoryState = new InventoryState();
    #endregion

    #endregion
    private void Start()
    {
        Movement = GetComponent<AgentMovement>();
        Input = GetComponent<PlayerInput>();
        AgentAnimations = GetComponent<HumanoidAnimations>();
        _currentState = movementState;
        _currentState.EnterState(this);
        AssignInputListeners();
    }

    private void AssignInputListeners()
    {
        Input.OnJump += HandleJump;
        Input.OnToggleInventory += HandleInventoryInput;
        Input.OnHotbarKey += HandleHotbarInput;
    }

    private void HandleJump()
    {
        _currentState.HandleJumpInput();
    }
    private void HandleInventoryInput()
    {
        _currentState.HandleInventoryInput();
    }
    private void HandleHotbarInput(int hotbarKey)
    {
        _currentState.HandleHotbarInput(hotbarKey);
    }
    private void OnDisable()
    {
        Input.OnJump -= _currentState.HandleJumpInput;
        Input.OnToggleInventory -= HandleInventoryInput;
        Input.OnHotbarKey -= HandleHotbarInput;
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
