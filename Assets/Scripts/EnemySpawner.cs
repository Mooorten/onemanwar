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

        // Gør det hurtigere
        currentSpawnInterval -= difficultyIncreaseRate;

        // Sørg for det ikke går under minimum
        currentSpawnInterval = Mathf.Max(currentSpawnInterval, minSpawnInterval);

        // Spawner næste enemy
        Invoke("SpawnEnemy", currentSpawnInterval);
    }
}
