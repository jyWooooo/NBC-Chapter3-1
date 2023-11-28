using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class PlayerNameInputField : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI messageUI;
    public int MinLength = 2;
    public int MaxLength = 10;
    [HideInInspector] public bool canCreateName = false;
    TMP_InputField _text;
    
    protected virtual void Start()
    {
        _text = GetComponent<TMP_InputField>();
        _text.text = DataManager.Instance.PlayerName ?? "";
    }

    public void SetName(string name)
    {
        if (canCreateName)
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
        else if (!IsValidLength(name, MinLength, MaxLength))
        {
            messageUI.text = $"Please enter within {MinLength} ~ {MaxLength} characters.";
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

    bool IsValidLength(string name, int minLength, int maxLength)
    {
        return minLength <= name.Length && name.Length <= maxLength;
    }
}