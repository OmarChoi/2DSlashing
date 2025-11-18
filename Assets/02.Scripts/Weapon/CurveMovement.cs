using UnityEngine;

public class CurveMovement : WeaponMovement
{
    private Vector2 _startPosition;
    private Vector2 _targetPosition;
    private Vector2 _controlPoint;
    private float _maxHeight = 10.0f;

    private float _elapsedPercentage = 0.0f;
    private float _duration = 3.0f;

    protected override void Init()
    {
        _targetPosition = GameObject.FindWithTag("Player").transform.position;
        _startPosition = transform.position;

        _duration = _duration / _moveSpeed;

        Vector2 controlPointOffset = Vector2.zero;
        controlPointOffset.y = Random.Range(0.5f * _maxHeight, _maxHeight);
        controlPointOffset.x = Random.Range(-1.0f, 1.0f);
        _controlPoint = (_startPosition + _targetPosition) * 0.5f + controlPointOffset;
    }

    protected override void Move()
    {
        if (_elapsedPercentage < 1f)
        {
            _elapsedPercentage += Time.deltaTime / _duration;

            Vector3 position =
                Mathf.Pow(1 - _elapsedPercentage, 2) * _startPosition +
                2 * (1 - _elapsedPercentage) * _elapsedPercentage * _controlPoint +
                Mathf.Pow(_elapsedPercentage, 2) * _targetPosition;

            transform.position = position;
            _moveDirection = (position - (Vector3)_targetPosition).normalized;
        }
        else
        {
            transform.position += (Vector3)_moveDirection * _moveSpeed * Time.deltaTime;
        }
    }
}
