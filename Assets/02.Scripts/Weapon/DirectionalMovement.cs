using UnityEngine;

public class DirectionalMovement : WeaponMovement
{
    protected override void Init()
    {
        float yOffset = Random.Range(-0.5f, 0.5f);
        Vector3 offset = new Vector3(0, yOffset);
        transform.position += offset;
    }
    protected override void Move()
    {
        transform.position += (Vector3)_moveDirection * _moveSpeed * Time.deltaTime;
    }
}
