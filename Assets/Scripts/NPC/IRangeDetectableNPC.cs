using System;
using UnityEngine;

public interface IRangeDetectableNPC
{
    public event Action<Collider2D> OnTriggerEntered;
    public event Action<Collider2D> OnTriggerExited;
    public event Action<Collider2D> OnTriggerStayed;

    public void OnTriggerEnter2D(Collider2D col);
    public void OnTriggerExit2D(Collider2D col);
    public void OnTriggerStay2D(Collider2D col);
}