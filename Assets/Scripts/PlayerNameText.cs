using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameText : MonoBehaviour
{
    [SerializeField] TextMeshPro nameText;

    void Start()
    {
        nameText.text = DataManager.Instance.PlayerName;
    }
}
