using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] PlayerController _controller;
    private float _currentHealth = 100.0f;
    private readonly float _maxHealth = 100.0f;

    private void Start()
    {
        _controller = GetComponent<PlayerController>();
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (_controller.CanTakeDamage == true) return;
        if (_controller.CurrentState == EPlayerState.Die) return;
        _currentHealth -= damage;
        _controller.OnHit();
        if (_currentHealth < 0)
        {
            _controller.OnDie();
        }
    }
}
