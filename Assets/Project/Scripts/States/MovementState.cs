using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : BaseState
{
    float fallingDelay = 0;
    public override void EnterState(AgentController controller)
    {
        base.EnterState(controller);
        fallingDelay = .2f;
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
            if(fallingDelay > 0)
            {
                fallingDelay -= Time.deltaTime;
                return;
            }
            controller.TransitionState(controller.fallingState);
        }
    }
}
