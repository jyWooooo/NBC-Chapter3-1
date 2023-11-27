using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static DataManager instance;

    public string PlayerName = "";

    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = new GameObject("DataManager");
                instance = obj.AddComponent<DataManager>();
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }
}