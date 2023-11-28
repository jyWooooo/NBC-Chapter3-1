using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCharacterButton : MonoBehaviour
{
    [SerializeField] CharacterChanger characterChanger;
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => { characterChanger.gameObject.SetActive(true); });
        characterChanger.OnSelected += SetImage;
        SetImage(DataManager.Instance.SelectCharacterIndex);
    }

    void SetImage(int selectIndex)
    {
        button.image.sprite = DataManager.Instance.characterPrefabs[selectIndex].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
    }
}