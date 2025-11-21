using UnityEngine;

public class ShurikenSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    private float _spawnInterval = 3.0f;
    private float _spawnCoolTime = 2.0f;
    private int[] _spawnWeights = { 200, 100 };
    private int _totalWeight = 0;

    private void Awake()
    {
        foreach (var weight in _spawnWeights)
        {
            _totalWeight += weight;
        }
    }

    private void Update()
    {
        _spawnCoolTime -= Time.deltaTime;
        if (_spawnCoolTime <= 0)
        {
            int currentCombo = ScoreManager.Instance.Combo;
            int comboWeight = currentCombo / 5 + 1;
            for(int i  = 0; i < comboWeight; i++)
            {
                SpawnEnemy();
            }
            _spawnCoolTime = _spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        float randomValue = UnityEngine.Random.value;
        float totalValue = 0.0f;
        int type = 0;
        for (int i = 0; i < _spawnWeights.Length; ++i)
        {
            totalValue += (float)_spawnWeights[i] / _totalWeight;
            if (randomValue < totalValue)
            {
                type = i;
                break;
            }
        }
        Instantiate(_enemyPrefabs[type], this.transform);
    }
}
