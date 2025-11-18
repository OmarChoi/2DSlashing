using UnityEngine;

public class MoveState : PlayerStateBase
{
    private Vector2 _direction = Vector2.right;
    private float _speed = 0.5f;
    private float _speedIncrease = 0.1f;
    private float _defaultSpeed = 1.0f;

    public MoveState(PlayerController controller) : base(controller) { }

    public override void Update()
    {
        int comboScale = ScoreManager.Instance.Combo;
        _speed = _defaultSpeed + _speedIncrease * comboScale;
        BackgroundScroller.Instance.UpdateBackground(_direction * _speed);
    }

    public override void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _controller.ChangeState(EPlayerState.Dodge);
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            _controller.ChangeState(EPlayerState.MiddleAttack);
            return;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            _controller.ChangeState(EPlayerState.HighAttack);
            return;
        }
    }
}
