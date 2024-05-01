using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState
{
    private bool _landingTrigger = false;
    private float _landingCheckTimer = 0f;
    public override void EnterState(AgentController controller)
    {
        base.EnterState(controller);
        _landingTrigger = false;
        _landingCheckTimer = .2f;
        controller.AgentAnimations.ResetTriggerLandingAnimation();
        controller.Movement.HandleJump();
    }
    public override void Update()
    {
        base.Update();
        if(_landingCheckTimer > 0)
        {
            _landingCheckTimer -= Time.deltaTime;
            return;
        }
        if (controller.Movement.IsGrounded())
        {
            if(_landingTrigger == false)
            {
                _landingTrigger = true;
                controller.AgentAnimations.TriggerLandingAnimation();
            }
            if (controller.Movement.HasFinishedJumping())
            {
                controller.TransitionState(controller.movementState);
            }
        }
        
    }
}
