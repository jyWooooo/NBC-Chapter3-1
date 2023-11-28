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
        // ReadValue�� InputActions asset���� ������ ���� �о�´�.
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

        // IPlayerControlActions�� ��ӹ޾� ���������Ƿ� this�� Callback�� ������ �� �ִ�.
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