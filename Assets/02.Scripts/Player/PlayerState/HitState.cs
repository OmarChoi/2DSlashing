using UnityEngine;

public class HitState : PlayerStateBase
{
    private PlayerController _controller = null;

    public HitState(PlayerController controller)
    {
        _controller = controller;
    }

    public override void Enter()
    {
        _controller.PlayerAnimator.SetTrigger("Hit");
    }

    public override void Update()
    {

    }
}
