using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class CharacterNameChanger : PlayerNameInputField
{
    [SerializeField] Button submitButton;
    [SerializeField] GameObject parentWindow;

    protected override void Start()
    {
        base.Start();
        submitButton.onClick.AddListener(Submit);
    }

    void Submit()
    {
        if (canCreateName)
        {
            CharacterInstantiator.Instance.player.GetComponentInChildren<PlayerNameText>().LoadName();
            parentWindow.SetActive(false);
        }
    }
}
