using UnityEngine;

public abstract class WeaponMovement : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 5.0f;
    protected float _defaultSpeed = 5.0f;
    protected Vector2 _moveDirection = Vector2.left;
    private void Awake()
    {
        _defaultSpeed = _moveSpeed;
        Init();
    }

    private void Update()
    {
        _moveDirection.Normalize();
        Move();
    }

    protected abstract void Move();
    protected virtual void Init() { }
}
