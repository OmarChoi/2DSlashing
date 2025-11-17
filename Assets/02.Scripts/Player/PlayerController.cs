using UnityEngine;
using System.Collections.Generic;

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
    private Animator _animator;
    public Animator PlayerAnimator => _animator;

    private SpriteRenderer _renderer;
    public SpriteRenderer PlayerRenderer => _renderer;

    private EPlayerState _currentState = EPlayerState.Idle;
    private Dictionary<EPlayerState, PlayerStateBase> _stateDictionary;

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
        PlayerStateBase currentState = _stateDictionary[_currentState];
        currentState.ProcessInput();
        currentState.Update();
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
