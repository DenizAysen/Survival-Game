using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInventory : MonoBehaviour
{
    [SerializeField]private GameObject inventoryGeneralPanel;

    public bool IsInventoryVisible { get => inventoryGeneralPanel.activeSelf; }

    private void Awake()
    {
        inventoryGeneralPanel.SetActive(false);
    }
    public void ToggleUI()
    {
        if (inventoryGeneralPanel.activeSelf)
        {
            inventoryGeneralPanel.SetActive(false);
        }
        else
            inventoryGeneralPanel.SetActive(true);
    }
}
