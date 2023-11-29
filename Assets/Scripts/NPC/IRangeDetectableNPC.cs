using System;
using UnityEngine;

public interface IRangeDetectableNPC
{
    public void OnRangeEnter(Collider2D col);
    public void OnRangeExit(Collider2D col);
    public void OnRangeStay(Collider2D col);
}