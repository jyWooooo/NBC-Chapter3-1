using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacterButton : MonoBehaviour
{
    public int index;
    public GameObject parentWindow;
    public Sprite sprite;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.image.sprite = sprite;
        button.onClick.AddListener(() => { DataManager.Instance.SelectCharacterIndex = index; });
        button.onClick.AddListener(() => { parentWindow?.SetActive(false); });
    }
}