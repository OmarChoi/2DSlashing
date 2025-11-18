using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EPlayerState
{
    Idle,
    Move,
    MiddleAttack,
    HighAttack,
    Dodge,
    Hit,
    Die
}

[System.Serializable]
public struct AttackInfo
{
    public EPlayerState State;
    public PlayerAttack AttackRange;
}

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    public Animator PlayerAnimator => _animator;

    private EPlayerState _currentState = EPlayerState.Move;
    public EPlayerState CurrentState => _currentState;
    private Dictionary<EPlayerState, PlayerStateBase> _stateDictionary;
    [SerializeField] private AttackInfo[] _attackInfos;
    public Vector2 Direction = Vector2.right;

    public bool CanTakeDamage = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _stateDictionary = new Dictionary<EPlayerState, PlayerStateBase>
        {
            { EPlayerState.Move,   new MoveState(this) },
            { EPlayerState.MiddleAttack, new MiddleAttackState(this) },
            { EPlayerState.HighAttack, new HighAttackState(this) },
            { EPlayerState.Dodge,  new DodgeState(this) },
            { EPlayerState.Hit,  new HitState(this) },
            { EPlayerState.Die,  new DieState(this) },
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
        if (_currentState == EPlayerState.Die) return;
        _stateDictionary[_currentState].Exit();
        _currentState = nextState;
        _stateDictionary[_currentState].Enter();
    }

    public void OnHit() => ChangeState(EPlayerState.Hit);
    public void OnDie() => ChangeState(EPlayerState.Die);

    public void OnAnimationEnd()
    {
        ChangeState(EPlayerState.Move);
    }

    public void OnAttack()
    {
        AttackInfo attackInfo = System.Array.Find(_attackInfos, info => info.State == _currentState);
        attackInfo.AttackRange.DoAttack();
    }
}
