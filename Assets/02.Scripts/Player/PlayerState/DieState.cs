using UnityEngine;

public class DieState : PlayerStateBase
{
    private PlayerController _controller = null;

    public DieState(PlayerController controller)
    {
        _controller = controller;
    }

    public override void Enter()
    {
        _controller.PlayerAnimator.SetBool("IsDie", true);
    }
}
