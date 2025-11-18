using UnityEngine;

public class DieState : PlayerStateBase
{
    public DieState(PlayerController controller) : base(controller) { }

    public override void Enter()
    {
        _controller.PlayerAnimator.SetBool("IsDie", true);
    }
}
