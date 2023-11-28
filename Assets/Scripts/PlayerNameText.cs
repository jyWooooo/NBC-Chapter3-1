using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameText : NameText
{
    protected override void Start()
    {
        LoadName();
        InvokeRepeating(nameof(SetBoundingBox), 0.1f, 1f);
    }

    public void LoadName()
    {
        nameText.text = DataManager.Instance.PlayerName;
    }
}