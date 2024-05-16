using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryState : BaseState
{
    public override void EnterState(AgentController controller)
    {
        base.EnterState(controller);
        Debug.Log("Open inventory window");
        controller.InventorySystem.ToggleInventory();
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public override void HandleInventoryInput()
    {
        base.HandleInventoryInput();
        Debug.Log("Close Inventory");
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller.InventorySystem.ToggleInventory();
        controller.TransitionState(controller.movementState);
    }
}
