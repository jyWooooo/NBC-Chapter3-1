using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCharacterButton : MonoBehaviour
{
    [SerializeField] protected CharacterChanger characterChanger;
    protected Button button;

    protected virtual void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => { characterChanger.gameObject.SetActive(true); });
    }
}