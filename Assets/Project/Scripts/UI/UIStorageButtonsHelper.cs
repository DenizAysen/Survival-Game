using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStorageButtonsHelper : MonoBehaviour
{
    public Action OnUseButtonClick, OnDropButtonClick;
    [SerializeField] private Button useBtn, dropBtn;
    void Start()
    {
        useBtn.onClick.AddListener(() => OnUseButtonClick?.Invoke());
        dropBtn.onClick.AddListener(() => OnDropButtonClick?.Invoke());
    }

    public void HideAllButtons()
    {
        ToggleDropButton(false);
        ToggleUseButton(false);
    }

    private void ToggleUseButton(bool value) => useBtn.interactable = value;

    private void ToggleDropButton(bool value) => dropBtn.interactable = value;
}
