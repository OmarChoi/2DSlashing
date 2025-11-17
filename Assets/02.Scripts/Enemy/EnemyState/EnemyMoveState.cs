using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoveState : EnemyStateBase
{
    private EnemyController _controller;
    private float _speed = 5.0f;
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
        if (_controller.ReachToTarget == true)
        {
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
        _controller.gameObject.transform.position = myPosition + direction * _speed * Time.deltaTime;
    }
}
