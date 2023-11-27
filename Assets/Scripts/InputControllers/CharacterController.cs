using UnityEngine;

public class CharacterController : PlayerController
{
    Rigidbody2D _rigidBody;
    SpriteRenderer _spriteRenderer;
    [SerializeField] float moveSpeed = 2f;

    Vector2 moveDirection;

    protected override void Start()
    {
        base.Start();
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        OnMoved += SetMoveDirection;
        OnLooked += SetLookFlip;
    }

    void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir.normalized;
    }

    void SetLookFlip(Vector2 mouseWorldPosition)
    {
        var lookDir = (mouseWorldPosition - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if (Mathf.Abs(angle) > 90f)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;
    }

    void FixedUpdate()
    {
        Move(moveDirection);
    }

    public void Move(Vector2 moveDirection) => _rigidBody.MovePosition(_rigidBody.position + moveSpeed * Time.fixedDeltaTime * moveDirection);
}