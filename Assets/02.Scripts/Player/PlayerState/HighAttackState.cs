using UnityEngine;

public class HighAttackState : PlayerStateBase
{
    public HighAttackState(PlayerController controller) : base(controller) { }

    public override void Enter()
    {
        _controller.PlayerAnimator.SetTrigger("HighAttack");
    }
}
