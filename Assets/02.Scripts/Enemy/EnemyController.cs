using UnityEngine;
using System.Collections.Generic;

public enum EEnemyState
{
    Move,
    Attack,
    Die,
    Carcass
}

public class EnemyController : MonoBehaviour
{
    public EnemyStatData StatData;

    private GameObject _player;
    public GameObject Player => _player;

    private Animator _animator;
    public Animator EnemyAnimator => _animator;

    private SpriteRenderer _renderer;
    public SpriteRenderer EnemyRenderer => _renderer;

    private EEnemyState _currentState = EEnemyState.Move;
    private Dictionary<EEnemyState, EnemyStateBase> _stateDictionary;

    [SerializeField] private EnemyAttack _attack;
    public bool PlayerInRange => _attack.PlayerInRange;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _stateDictionary = new Dictionary<EEnemyState, EnemyStateBase>
        {
            { EEnemyState.Move,   new EnemyMoveState(this) },
            { EEnemyState.Attack,   new EnemyAttackState(this) },
        };
    }

    private void Update()
    {
        _stateDictionary[_currentState].Update();
    }

    public void ChangeState(EEnemyState nextState)
    {
        _stateDictionary[_currentState].Exit();
        _currentState = nextState;
        _stateDictionary[_currentState].Enter();
    }

    public void OnAnimationEnd() => ChangeState(EEnemyState.Move);
    public void OnAttack() => _attack.ApplyDamage(StatData.Damage);
}
