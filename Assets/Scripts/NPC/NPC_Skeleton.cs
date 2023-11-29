using System;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Skeleton : NPC, IHitableNPC, IConversableNPC
{
    [SerializeField] SpeechBubble speechBubble;

    List<string> hitedScripts = new()
    {
        @"!",
        @"T^T",
        @"Stop, {PlayerName}.",
    };

    public event Action<string> OnConversationEntered;

    protected override void Start()
    {
        base.Start();
        OnConversationEntered += Speech;
    }

    public void Speech(string script)
    {
        script = ScriptConverter.Convert(script);
        speechBubble.Enable(script);
    }

    public void OnConversationEnter(string script) => OnConversationEntered?.Invoke(script);

    public void OnConversationLeave(string script) { }

    string RandomScriptInList(List<string> scripts)
    {
        return scripts[UnityEngine.Random.Range(0, scripts.Count)];
    }

    public void OnHit()
    {
        OnConversationEnter(RandomScriptInList(hitedScripts));
    }
}