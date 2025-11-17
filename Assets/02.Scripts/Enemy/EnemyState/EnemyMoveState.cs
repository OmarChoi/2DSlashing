using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoveState : EnemyStateBase
{
    private EnemyController _controller;
    private float _remainAttackTime = 0;
    private float _distanceOffset = 0.5f;

    public EnemyMoveState(EnemyController controller)
    {
        _controller = controller;
    }

    public override void Update()
    {
        if (CheckTarget() == true) return;
        MoveToTarget();
    }

private bool CheckTarget()
    {
        _remainAttackTime -= Time.deltaTime;
        if (_controller.PlayerInRange == true)
        {
            if (_remainAttackTime > 0) return false;
            _remainAttackTime = _controller.StatData.AttackCoolTime;
            _controller.ChangeState(EEnemyState.Attack);
            return true;
        }
        return false;
    }

    private void MoveToTarget()
    {
        Vector2 targetPosition = _controller.Player.transform.position;
        Vector2 myPosition = _controller.gameObject.transform.position;
        Vector2 direction = targetPosition - myPosition;
        if (direction.magnitude < _distanceOffset) return;
        direction.y = 0;
        direction.Normalize();
        if (direction.x > 0)
        {
            _controller.EnemyRenderer.flipX = true;
        }
        else
        {
            _controller.EnemyRenderer.flipX = false;
        }
        _controller.gameObject.transform.position = myPosition + direction * _controller.StatData.MoveSpeed * Time.deltaTime;
    }
}
