using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChanger : MonoBehaviour
{
    public List<SelectCharacterButton> buttons;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform content;
    public event Action<int> OnSelected;

    void Start()
    {
        buttons = new();

        var characterList = DataManager.Instance.characterPrefabs;
        for (int i = 0; i < characterList.Count; i++)
        {
            var button = Instantiate(buttonPrefab, content).GetComponent<Button>();
            button.name = $"Select {characterList[i].name} Button";
            buttons.Add(button.GetComponent<SelectCharacterButton>());
            buttons[i].index = i;
            buttons[i].sprite = characterList[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            buttons[i].parentWindow = gameObject;
        }
    }
    private void OnDisable()
    {
        OnSelected?.Invoke(DataManager.Instance.SelectCharacterIndex);
    }
}