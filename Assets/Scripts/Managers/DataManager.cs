using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static DataManager instance;

    public string PlayerName;
    public List<GameObject> characterPrefabs;
    public int SelectCharacterIndex;

    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = new GameObject(nameof(DataManager));
                instance = obj.AddComponent<DataManager>();
                instance.Initialize();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            instance.Initialize();
        }
    }

    public void Initialize()
    {
        PlayerName = "";
        characterPrefabs = new List<GameObject>();
        LoadCharacterPrefabs();
        SelectCharacterIndex = 0;
        DontDestroyOnLoad(gameObject);
    }

    public bool LoadCharacterPrefabs()
    {
        characterPrefabs = Resources.LoadAll<GameObject>("Characters").ToList();
        return characterPrefabs.Count > 0;
    }
}