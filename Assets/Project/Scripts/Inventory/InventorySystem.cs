using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private UiInventory _uiInventory;
    private void Awake()
    {
        _uiInventory = GetComponent<UiInventory>();
    }
    public void ToggleInventory()
    {
        if (!_uiInventory.IsInventoryVisible)
        {

        }
        _uiInventory.ToggleUI();
    }
}
