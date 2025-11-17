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

    public override void Update()
    {
        // 범위 안에 존재하는 적에게 데미지 적용
    }
}
