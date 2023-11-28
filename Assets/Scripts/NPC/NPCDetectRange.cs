using UnityEngine;

public class NPCDetectRange : MonoBehaviour
{
    IRangeDetectableNPC parent;

    void Start()
    {
        parent = GetComponentInParent<IRangeDetectableNPC>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            parent.OnRangeEnter(col);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            parent.OnRangeExit(col);
    }
}