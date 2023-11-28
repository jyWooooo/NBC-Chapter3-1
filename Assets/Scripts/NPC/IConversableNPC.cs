using System;

public interface IConversableNPC
{
    public event Action<string> OnConversationEntered;
    public event Action<string> OnConversationLeaved;

    public void OnConversationEnter();
    public void OnConversationLeave();
}