using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    private float _spawnInterval = 5.0f;
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
        _spawnInterval -= Time.deltaTime;
        if (_spawnInterval <= 0)
        {
            SpawnEnemy();
            _spawnInterval = 2.0f;
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
