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
    [Header("Item Info")]
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
    public void SetInventoryUIElement(string name, int count, Sprite image)
    {
        itemName = name;
        itemCount = count.ToString();
        if (!isHotbarItem)
            nameText.text = itemName;
        countText.text = itemCount;
        isEmpty = false;
        SetImageSprite(image);
    }

    private void SetImageSprite(Sprite image) => itemImage.sprite = image;
    public void SwapWithData(string name, int count, Sprite image, bool isEmpty)
    {
        SetInventoryUIElement(name, count, image);
        this.isEmpty = isEmpty;
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
