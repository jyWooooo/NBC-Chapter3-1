using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneChangeCharacterButton : ChangeCharacterButton
{
    protected override void Start()
    {
        base.Start();
        characterChanger.OnSelected += SetImage;
        SetImage(DataManager.Instance.SelectCharacterIndex);
    }

    void SetImage(int selectIndex)
    {
        button.image.sprite = DataManager.Instance.characterPrefabs[selectIndex].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
    }
}