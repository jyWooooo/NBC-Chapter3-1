using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameText : MonoBehaviour
{
    [SerializeField] TextMeshPro nameText;
    [SerializeField] Transform boundingBox;

    public Vector2 boundingBoxMagin = new(0.1f, 0.1f);

    void Start()
    {
        nameText.text = DataManager.Instance.PlayerName;
        InvokeRepeating(nameof(SetBoundingBox), 0.1f, 1f);
    }
    void SetBoundingBox()
    {
        boundingBox.localScale = (Vector2)nameText.bounds.size + boundingBoxMagin;
    }
}