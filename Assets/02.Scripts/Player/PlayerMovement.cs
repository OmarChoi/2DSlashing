using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator _animator = null;
    private SpriteRenderer _renderer = null;

    private Vector2 _direction = Vector2.right;
    private bool _lookLeft = false;

    private float _speed = 5.0f;
    private float _minX = -8.0f;
    private float _maxX = 8.0f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        UpdatePosition();
        SetAnimation();
    }

    private void SetAnimation()
    {
        _animator.SetBool("IsMove", _direction.magnitude > float.Epsilon);
        if (_direction.x == 0) return;
        _lookLeft = (_direction.x < 0);
        _renderer.flipX = _lookLeft;
    }

    private void UpdatePosition()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        _direction = new Vector2(horizontalMovement, 0).normalized;
        Vector2 nextPosition = (Vector2)transform.position + _direction * _speed * Time.deltaTime;
        nextPosition.x = Mathf.Clamp(nextPosition.x, _minX, _maxX);
        transform.position = nextPosition;
    }
}
