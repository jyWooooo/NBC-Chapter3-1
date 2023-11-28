using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInputAction.IPlayerControlActions
{
    PlayerInputAction inputAction;

    public event Action<Vector2> OnMoved;
    public event Action<Vector2> OnLooked;

    public virtual void OnMove(InputAction.CallbackContext context)
    {
        // ReadValue로 InputActions asset에서 설정한 값을 읽어온다.
        OnMoved?.Invoke(context.ReadValue<Vector2>());
    }

    public virtual void OnLook(InputAction.CallbackContext context)
    {
        // convert world position
        var pos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        OnLooked?.Invoke(pos);
    }

    protected virtual void Start()
    {
        //if (inputAction == null)
        //    inputAction = new();
        inputAction ??= new();

        // IPlayerControlActions를 상속받아 구현했으므로 this로 Callback을 설정할 수 있다.
        inputAction?.PlayerControl.SetCallbacks(this);
        inputAction?.Enable();
    }

    private void OnDisable()
    {
        inputAction?.Disable();
    }

    private void OnDestroy()
    {
        inputAction?.Dispose();
    }
}