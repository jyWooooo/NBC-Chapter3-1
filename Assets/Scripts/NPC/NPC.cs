using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName;
    [SerializeField] NameText nameText;

    protected virtual void Start()
    {
        nameText.SetName(npcName);
    }
}