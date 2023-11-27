using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerNameInputField : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI messageUI;
    public int MaxLength = 10;
    public bool canCreateName = false;

    public void SetName(string name)
    {
        DataManager.Instance.PlayerName = name;
    }

    public void SetMessage(string name)
    {
        if (!IsLetterOrDigit(name))
        {
            messageUI.text = "Please enter only numbers or letters.";
            messageUI.color = Color.red;
            canCreateName = false;
        }
        else if (!IsMaxLength(name, MaxLength))
        {
            messageUI.text = $"Please enter within {MaxLength} characters.";
            messageUI.color = Color.red;
            canCreateName = false;
        }
        else
        {
            messageUI.text = "is valid name.";
            messageUI.color = Color.green;
            canCreateName = true;
        }
    }

    bool IsLetterOrDigit(string name)
    {
        foreach (var c in name)
            if (!char.IsLetterOrDigit(c))
                return false;
        return true;
    }

    bool IsMaxLength(string name, int maxLength)
    {
        return name.Length <= maxLength;
    }
}
