using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameText : MonoBehaviour
{
    [SerializeField] protected TextMeshPro nameText;
    [SerializeField] protected Transform boundingBox;

    public Vector2 boundingBoxMagin = new(0.1f, 0.1f);

    protected virtual void Start()
    {
        InvokeRepeating(nameof(SetBoundingBox), 0.1f, 1f);
    }

    public virtual void SetName(string name)
    {
        nameText.text = name;
    }

    protected virtual void SetBoundingBox()
    {
        boundingBox.localScale = (Vector2)nameText.bounds.size + boundingBoxMagin;
    }
}