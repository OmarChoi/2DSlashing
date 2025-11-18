using UnityEngine;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour
{
    List<Collider2D> _hitColliders = new List<Collider2D>();
    [SerializeField] private GameObject _effectObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon") == false) return;
        if (_hitColliders.Contains(other) == true) return;
        _hitColliders.Add(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Weapon") == false) return;
        _hitColliders.Remove(other);
    }

    public void DoAttack()
    {
        Instantiate(_effectObject, this.transform);
        List<Collider2D> destroyList = new List<Collider2D>();
        for (int i = _hitColliders.Count - 1; i >= 0; --i)
        {
            Collider2D target = _hitColliders[i];
            if (target == null)
            {
                _hitColliders.RemoveAt(i);
                continue;
            }
            destroyList.Add(target);
        }

        foreach (Collider2D target in destroyList)
        {
            Destroy(target.gameObject);
            ScoreManager.Instance.AddScore();
        }
    }
}
