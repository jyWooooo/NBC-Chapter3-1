using System;
using UnityEngine;

public class ScriptConverter
{
    public static string Convert(string script)
    {
        string res = script;
        res = res.Replace(@"{PlayerName}", DataManager.Instance.PlayerName);
        res = res.Replace(@"{DateTime}", DateTime.Now.ToString("HH:mm"));
        return res;
    }
}