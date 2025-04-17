using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // Fjern kuglen
            Destroy(gameObject);       // Fjern fjenden
            ScoreManager.instance.AddScore(1); // Giv +1 score
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
            Destroy(other.gameObject); // Fjern spilleren
            Time.timeScale = 0f;       // Stop spillet
        }
    }
}
