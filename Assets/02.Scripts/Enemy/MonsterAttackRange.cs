using UnityEngine;

public class MonsterAttackRange : MonoBehaviour
{
    private bool _playerInRange = false;
    public bool PlayerInRange => _playerInRange;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == false) return;
        _playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") == false) return;
        _playerInRange = false;
    }
}
