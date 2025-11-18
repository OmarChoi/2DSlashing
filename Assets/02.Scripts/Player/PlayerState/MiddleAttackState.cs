using UnityEngine;

public class MiddleAttackState : PlayerStateBase
{
    public MiddleAttackState(PlayerController controller) : base(controller) { }

    public override void Enter()
    {
        _controller.PlayerAnimator.SetTrigger("MiddleAttack");
    }
}
