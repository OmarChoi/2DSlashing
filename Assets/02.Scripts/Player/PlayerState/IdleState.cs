using UnityEngine;

public class IdleState : PlayerStateBase
{
    private PlayerController _controller;

    public IdleState(PlayerController controller)
    {
        _controller = controller;
    }

    public override void Update()
    {
        // 일정 시간 지나면 Idle2 애니메이션 실행
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

        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(horizontalMovement) > float.Epsilon)
        {
            _controller.ChangeState(EPlayerState.Move);
            return;
        }
    }
}
