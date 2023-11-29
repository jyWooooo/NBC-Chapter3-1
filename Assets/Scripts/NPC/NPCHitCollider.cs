using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHitCollider : MonoBehaviour
{
    IHitableNPC parent;

    void Start()
    {
        parent = GetComponentInParent<IHitableNPC>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)
            parent.OnHit();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 8)
            parent.OnHit();
    }
}
