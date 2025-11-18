using UnityEngine;

public class HitState : PlayerStateBase
{
    public HitState(PlayerController controller) : base(controller) { }

    public override void Enter()
    {
        _controller.PlayerAnimator.SetTrigger("Hit");
        ScoreManager.Instance.ResetCombo();
    }
}
