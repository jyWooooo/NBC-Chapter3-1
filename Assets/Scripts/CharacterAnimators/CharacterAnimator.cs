using System;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] CharacterController _controller;
    Animator _animator;

    public enum State
    {
        Idle,
        Run,
    }
    protected State _state;
    public State CurrentState { get => _state; set { _state = value; SetState(_state); } }

    void Start()
    {
        _controller = GetComponentInParent<CharacterController>();
        _animator = GetComponent<Animator>();
        _controller.OnMoved += IsMoved;
    }

    public void IsMoved(Vector2 dir)
    {
        if (dir.magnitude > 0f)
            CurrentState = State.Run;
        else
            CurrentState = State.Idle;
    }

    void SetState(State state) => _animator.SetInteger("State", (int)state);
}