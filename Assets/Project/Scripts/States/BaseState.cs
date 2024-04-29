using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState 
{
    protected AgentController controller;
    public virtual void EnterState(AgentController controller)
    {
        this.controller = controller;
    }
    public virtual void HandleMovement(Vector2 input)
    {

    }
    public virtual void HandleCameraDirection(Vector3 input)
    {

    }
    public virtual void HandleJumpInput()
    {

    }
    public virtual void Update()
    {

    }
}
