using UnityEngine;

public class CharacterController : PlayerController
{
    Rigidbody2D _rigidBody;
    SpriteRenderer _spriteRenderer;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform bow;

    Vector2 moveDirection;
    Vector2 aimDirection;

    protected override void Start()
    {
        base.Start();
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        OnMoved += SetMoveDirection;
        OnLooked += SetLookFlip;
        OnFired += Fire;
    }

    void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir.normalized;
    }

    void SetLookFlip(Vector2 mouseWorldPosition)
    {
        aimDirection = (mouseWorldPosition - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        if (Mathf.Abs(angle) > 90f)
        {
            bow.localScale = new(-1, 1, 1);
            _spriteRenderer.flipX = true;
        }
        else
        {
            bow.localScale = new(1, 1, 1);
            _spriteRenderer.flipX = false;
        }
    }

    void Fire()
    {
        var arrow =Instantiate(arrowPrefab, bow.GetChild(0).position, Quaternion.identity);
        arrow.transform.up = aimDirection;
    }

    void FixedUpdate()
    {
        Move(moveDirection);
    }

    public void Move(Vector2 moveDirection) => _rigidBody.MovePosition(_rigidBody.position + moveSpeed * Time.fixedDeltaTime * moveDirection);
}