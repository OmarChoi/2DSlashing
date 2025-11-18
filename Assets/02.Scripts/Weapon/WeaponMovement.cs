using UnityEngine;

public abstract class WeaponMovement : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 5.0f;
    protected float _defaultSpeed = 5.0f;
    protected float _increaseSpeed = 0.2f;
    protected Vector2 _moveDirection = Vector2.left;
    private void Awake()
    {
        _defaultSpeed = _moveSpeed;
        Init();
    }

    private void Update()
    {
        _moveSpeed = _defaultSpeed + (_defaultSpeed * ScoreManager.Instance.Combo * _increaseSpeed);
        _moveDirection.Normalize();
        Move();
    }

    protected abstract void Move();
    protected virtual void Init() { }
}
