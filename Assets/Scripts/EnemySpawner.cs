using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    public float initialSpawnInterval = 2f;
    public float minSpawnInterval = 0.3f;
    public float difficultyIncreaseRate = 0.05f;

    public float startDelay = 3f; // hvor lang tid før første spawn

    private float currentSpawnInterval;

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        Invoke("SpawnEnemy", startDelay); // vente med første spawn
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        currentSpawnInterval -= difficultyIncreaseRate;
        currentSpawnInterval = Mathf.Max(currentSpawnInterval, minSpawnInterval);

        Invoke("SpawnEnemy", currentSpawnInterval);
    }
}
