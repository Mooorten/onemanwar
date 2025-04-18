using UnityEngine;
using TMPro;

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

        // Fjern y-bevægelse så fjenden går vandret
        direction.y = 0;

        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // Fjern kuglen
            Destroy(gameObject);       // Fjern fjenden

            // Tilføj point
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(1);
            }
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
            Destroy(other.gameObject); // Fjern spilleren
            Time.timeScale = 0f;       // Stop spillet

            // Vis Game Over UI med score
            if (GameOverUI.instance != null && ScoreManager.instance != null)
            {
                GameOverUI.instance.Show(ScoreManager.instance.GetScore());
            }
        }
    }
}
