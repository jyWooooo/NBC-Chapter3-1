using System;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Lizard : NPC, IRangeDetectableNPC, IConversableNPC
{
    [SerializeField] SpeechBubble speechBubble;
    SpriteRenderer spriteRenderer;

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

    public event Action<string> OnConversationEntered;
    public event Action<string> OnConversationLeaved;

    protected override void Start()
    {
        base.Start();
        OnConversationEntered += Speech;
        OnConversationLeaved += Speech;
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void Speech(string script)
    {
        script = ScriptConverter.Convert(script);
        speechBubble.Enable(script);
    }

    public void OnConversationEnter(string script) => OnConversationEntered?.Invoke(script);

    public void OnConversationLeave(string script) => OnConversationLeaved?.Invoke(script);

    public void OnRangeEnter(Collider2D col)
    { 
        OnConversationEnter(RandomScriptInList(RangeDetectEnteredScripts));

        // 플레이어를 감지하면 플레이어를 바라본다
        if (col.transform.position.x < transform.position.x)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;

    }

    public void OnRangeExit(Collider2D col) => OnConversationLeave(RandomScriptInList(RangeDetectExitedScripts));

    public void OnRangeStay(Collider2D col) { }

    string RandomScriptInList(List<string> scripts)
    {
        return scripts[UnityEngine.Random.Range(0, scripts.Count)];
    }
}