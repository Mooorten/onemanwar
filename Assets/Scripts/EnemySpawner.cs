using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    public float initialSpawnInterval = 2f; // starter langsomt
    public float minSpawnInterval = 0.3f;   // aldrig hurtigere end det her
    public float difficultyIncreaseRate = 0.05f; // hvor meget den bliver hurtigere hver gang

    private float currentSpawnInterval;

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        Invoke("SpawnEnemy", currentSpawnInterval);
    }

    void SpawnEnemy()
    {
        // Spawn enemy
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // G�r det hurtigere
        currentSpawnInterval -= difficultyIncreaseRate;

        // S�rg for det ikke g�r under minimum
        currentSpawnInterval = Mathf.Max(currentSpawnInterval, minSpawnInterval);

        // Spawner n�ste enemy
        Invoke("SpawnEnemy", currentSpawnInterval);
    }
}
