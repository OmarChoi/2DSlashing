using UnityEngine;

public class DodgeState : PlayerStateBase
{
    public DodgeState(PlayerController controller) : base(controller) { }

    public override void Enter()
    {
        _controller.PlayerAnimator.SetTrigger("Dodge");
        _controller.CanTakeDamage = false;
    }

    public override void Exit()
    {
        _controller.CanTakeDamage = true;
    }
}