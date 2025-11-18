using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    [SerializeField] private float _damage = 10.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == false) return;
        if (other.GetComponent<IDamageable>()?.TakeDamage(_damage) == false) return;
        Destroy(gameObject);
    }
}
