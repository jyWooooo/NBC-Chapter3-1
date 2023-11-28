using System;

public interface IConversableNPC
{
    public event Action<string> OnConversationEntered;
    public event Action<string> OnConversationLeaved;

    public void OnConversationEnter(string script);
    public void OnConversationLeave(string script);
}