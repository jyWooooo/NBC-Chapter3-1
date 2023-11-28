using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterInstantiator : MonoBehaviour
{
    static CharacterInstantiator instance;

    public static CharacterInstantiator Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = new GameObject(nameof(CharacterInstantiator));
                instance = obj.AddComponent<CharacterInstantiator>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Instantiate(DataManager.Instance.characterPrefabs[DataManager.Instance.SelectCharacterIndex], Vector3.zero, Quaternion.identity);
    }
}
