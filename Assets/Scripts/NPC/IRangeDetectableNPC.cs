using System;
using UnityEngine;

public interface IRangeDetectableNPC
{
    public event Action<Collider2D> OnRangeEntered;
    public event Action<Collider2D> OnRangeExited;
    public event Action<Collider2D> OnRangeStayed;

    public void OnRangeEnter(Collider2D col);
    public void OnRangeExit(Collider2D col);
    public void OnRangeStay(Collider2D col);
}