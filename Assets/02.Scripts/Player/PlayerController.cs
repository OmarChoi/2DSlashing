using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public enum EPlayerState
{
    Idle,
    Move,
    Attack,
    Dodge,
    Die
}

public class PlayerController : MonoBehaviour
{
    private Animator _animator = null;
    public Animator PlayerAnimator => _animator;

    private SpriteRenderer _renderer = null;
    public SpriteRenderer PlayerRenderer => _renderer;

    private EPlayerState _currentState = EPlayerState.Idle;
    private Dictionary<EPlayerState, PlayerStateBase> _stateDictionary = new Dictionary<EPlayerState, PlayerStateBase>();

    public Vector2 Direction = Vector2.right;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _stateDictionary = new Dictionary<EPlayerState, PlayerStateBase>
        {
            { EPlayerState.Idle,   new IdleState(this) },
            { EPlayerState.Move,   new MoveState(this) },
            { EPlayerState.Attack, new AttackState(this) },
            { EPlayerState.Dodge,  new DodgeState(this) },
        };
    }

    private void Update()
    {
        _stateDictionary[_currentState].ProcessInput();
        _stateDictionary[_currentState].Update();
    }

    public void ChangeState(EPlayerState nextState)
    {
        _stateDictionary[_currentState].Exit();
        _currentState = nextState;
        _stateDictionary[_currentState].Enter();
    }

    public void OnAnimationEnd()
    {
        ChangeState(EPlayerState.Idle);
    }
}
