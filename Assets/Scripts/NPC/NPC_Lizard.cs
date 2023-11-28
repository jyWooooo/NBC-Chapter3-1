using System;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Lizard : NPC, IRangeDetectableNPC, IConversableNPC
{
    [SerializeField] SpeechBubble speechBubble;

    List<string> RangeDetectEnteredScripts = new() 
    {
        @"growl",
        @"!",
        @"DateTime : {DateTime}",
    };
    List<string> RangeDetectExitedScripts = new() 
    {
        @"bye {PlayerName}",
        @"...",
    };

    public event Action<Collider2D> OnRangeEntered;
    public event Action<Collider2D> OnRangeExited;
    public event Action<Collider2D> OnRangeStayed;
    public event Action<string> OnConversationEntered;
    public event Action<string> OnConversationLeaved;

    protected override void Start()
    {
        base.Start();
        OnRangeEntered += OnConversationEnter;
        OnRangeExited += OnConversationLeave;
        OnConversationEntered += Speech;
        OnConversationLeaved += Speech;
    }

    public void Speech(string script)
    {
        script = ScriptConverter.Convert(script);
        speechBubble.Enable(script);
    }

    public void OnConversationEnter(string script)
    {
        OnConversationEntered?.Invoke(script);
    }
    public void OnConversationEnter(Collider2D col)
    {
        OnConversationEnter(RandomScriptInList(RangeDetectEnteredScripts));
    }

    public void OnConversationLeave(string script)
    {
        OnConversationEntered?.Invoke(script);
    }
    public void OnConversationLeave(Collider2D col)
    {
        OnConversationLeave(RandomScriptInList(RangeDetectExitedScripts));
    }

    public void OnRangeEnter(Collider2D col)
    {
        OnRangeEntered?.Invoke(col);
    }

    public void OnRangeExit(Collider2D col)
    {
        OnRangeExited?.Invoke(col);
    }

    public void OnRangeStay(Collider2D col)
    {
        //OnTriggerStayed?.Invoke(col);
    }

    string RandomScriptInList(List<string> scripts)
    {
        return scripts[UnityEngine.Random.Range(0, scripts.Count)];
    }
}