using UnityEngine;

public class MoveState : PlayerStateBase
{
    private PlayerController _controller;
    private readonly float _speed = 8.0f;
    private readonly float _minX = -8.0f;
    private readonly float _maxX = 8.0f;

    public MoveState(PlayerController controller)
    {
        _controller = controller;
    }

    public override void Enter()
    {
        _controller.PlayerAnimator.SetBool("IsMove", true);
    }

    public override void Exit()
    {
        _controller.PlayerAnimator.SetBool("IsMove", false);
    }

    public override void Update()
    {
        SetDirection();
        UpdatePosition();
    }

    public override void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _controller.ChangeState(EPlayerState.Dodge);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _controller.ChangeState(EPlayerState.Attack);
            return;
        }
    }

    private void UpdatePosition()
    {
        Vector2 currentPosition = _controller.gameObject.transform.position;
        Vector2 nextPosition = currentPosition + _controller.Direction * _speed * Time.deltaTime;
        if (nextPosition.x > _maxX)
        {
            BackgroundScroller.Instance.UpdateBackground(Vector2.right);
        }
        nextPosition.x = Mathf.Clamp(nextPosition.x, _minX, _maxX);
        _controller.gameObject.transform.position = nextPosition;
    }

    private void SetDirection()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(horizontalMovement) < float.Epsilon)
        {
            _controller.ChangeState(EPlayerState.Idle);
            return;
        }
        if (horizontalMovement < 0f)
        {
            _controller.PlayerRenderer.flipX = true;
            _controller.Direction = Vector2.left;
        }
        else
        {
            _controller.PlayerRenderer.flipX = false;
            _controller.Direction = Vector2.right;
        }
    }
}
