using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanelHelper : MonoBehaviour
{
    public Action<int, bool> OnClickEvent;

    [Header("UI")]
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI nameText, countText;
    private Outline itemOutline;
    [SerializeField] private Sprite backgroundSprite;

    [Header("Item info")]
    [SerializeField] private string itemName, itemCount;
    [SerializeField] private bool isEmpty = true;
    [SerializeField] private bool isHotbarItem = false;
    private void Awake()
    {
        itemOutline = GetComponent<Outline>();
        itemOutline.enabled = false;
        if(itemImage.sprite == backgroundSprite)
        {
            ClearItem();
        }
    }

    private void ClearItem()
    {
        itemName = "";
        itemCount = "";
        countText.text = itemCount;
        if (!isHotbarItem)
        {
            nameText.text = itemName;
        }
        ResetImage();
        isEmpty = true;
        ToggleHighlight(false);
    }

    private void ToggleHighlight(bool value) => itemOutline.enabled = value;

    private void ResetImage()
    {
        itemImage.sprite = backgroundSprite;
    }
}
