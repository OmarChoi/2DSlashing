using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyStat")]
public class EnemyStatData : ScriptableObject
{
    public float MaxHealth;
    public float MoveSpeed;
    public float AttackCoolTime;
    public float Damage;
}