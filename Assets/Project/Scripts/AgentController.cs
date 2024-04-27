using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    public AgentMovement Movement;
    public PlayerInput Input;
    private void Start()
    {
        Movement = GetComponent<AgentMovement>();
        Input = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        Movement.HandleMovement(Input.MovementInputVector);
        Movement.HandleMovementDirection(Input.MovementDirectionVector);
    }
}
