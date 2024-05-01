using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : BaseState
{
    float _fallingDelay = 0;
    float _defaultFallingDelay = .2f;
    public override void EnterState(AgentController controller)
    {
        base.EnterState(controller);
        _fallingDelay = _defaultFallingDelay;
    }
    public override void HandleMovement(Vector2 input)
    {
        base.HandleMovement(input);
        controller.Movement.HandleMovement(input);
    }
    public override void HandleCameraDirection(Vector3 input)
    {
        base.HandleCameraDirection(input);
        controller.Movement.HandleMovementDirection(input);
    }
    public override void HandleJumpInput()
    {
        controller.TransitionState(controller.jumpState);
    }
    public override void Update()
    {
        base.Update();
        HandleMovement(controller.Input.MovementInputVector);
        HandleCameraDirection(controller.Input.MovementDirectionVector);
        if (controller.Movement.IsGrounded() == false)
        {
            if(_fallingDelay > 0)
            {
                _fallingDelay -= Time.deltaTime;
                return;
            }
            controller.TransitionState(controller.fallingState);
        }
        else
        {
            _fallingDelay = .2f;
        }
    }
}
