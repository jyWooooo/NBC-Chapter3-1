using System;

public interface IHitableNPC
{
    public event Action OnHited;

    public void OnHit();
}