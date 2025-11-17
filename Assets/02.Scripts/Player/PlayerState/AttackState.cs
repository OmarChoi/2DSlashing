using UnityEngine;

public class AttackState : PlayerStateBase
{
    private PlayerController _controller;

    public AttackState(PlayerController controller)
    {
        _controller = controller;
    }

    public override void Enter()
    {
        _controller.PlayerAnimator.SetTrigger("MiddleAttack");
    }
}
