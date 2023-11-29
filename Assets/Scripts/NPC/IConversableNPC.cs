using System;

public interface IConversableNPC
{
    public void OnConversationEnter(string script);
    public void OnConversationLeave(string script);
}