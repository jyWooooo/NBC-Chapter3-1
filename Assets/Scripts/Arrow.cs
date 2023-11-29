using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;
    Rigidbody2D rigid;
    float t;
    private void Start()
    {
        t = 0f;
        rigid = GetComponentInChildren<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        t += Time.fixedDeltaTime;
        if (t > lifeTime) 
            Destroy(gameObject);
        rigid.MovePosition(rigid.position + speed * Time.fixedDeltaTime * (Vector2)transform.up);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.contactCount > 0)
            transform.up = Vector2.Reflect(transform.up, col.contacts[0].normal);
    }
}