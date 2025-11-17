using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 5.0f;
    private Vector2 _direction = Vector2.right;
    public Vector2 Direction => _direction;
    private Animator _animator = null;
    private SpriteRenderer _renderer = null;

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
        _renderer.flipX = (_direction.x < 0);
    }

    private void UpdatePosition()
    {
        float verticalMovement = Input.GetAxisRaw("Vertical");
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        _direction = new Vector2(horizontalMovement, verticalMovement).normalized;
        this.transform.position += (Vector3)_direction * _speed * Time.deltaTime;
    }
}
