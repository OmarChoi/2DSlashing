using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private GameObject _player;
    private bool _playerInRange = false;
    public bool PlayerInRange => _playerInRange;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == false) return;
        _player = other.gameObject;
        _playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") == false) return;
        _player = null;
        _playerInRange = false;
    }

    public void ApplyDamage(float damage)
    {
        if (_player == null) return;
        _player.GetComponent<IDamageable>().TakeDamage(damage);
    }
}
