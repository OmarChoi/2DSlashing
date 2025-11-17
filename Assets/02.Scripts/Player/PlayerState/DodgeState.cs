using UnityEngine;

public class DodgeState : PlayerStateBase
{
    private PlayerController _controller = null;
    private readonly float _dodgeSpeed = 8.0f;
    private readonly float _minX = -8.0f;
    private readonly float _maxX = 8.0f;

    public DodgeState(PlayerController controller)
    {
        _controller = controller;
    }

    public override void Enter()
    {
        _controller.PlayerAnimator.SetTrigger("Dodge");
    }

    public override void Update()
    {
        Vector2 currentPosition = _controller.gameObject.transform.position;
        Vector2 nextPosition = currentPosition + _controller.Direction * _dodgeSpeed * Time.deltaTime;
        nextPosition.x = Mathf.Clamp(nextPosition.x, _minX, _maxX);
        _controller.gameObject.transform.position = nextPosition;
    }
}