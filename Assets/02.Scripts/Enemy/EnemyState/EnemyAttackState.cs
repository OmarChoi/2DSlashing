using UnityEngine;
using UnityEngine.InputSystem.XR;

public class EnemyAttackState : EnemyStateBase
{
    private EnemyController _controller;

    public EnemyAttackState(EnemyController controller)
    {
        _controller = controller;
    }

    public override void Enter()
    {
        _controller.EnemyAnimator.SetTrigger("Attack");
    }

    public override void Update()
    {

    }
}
