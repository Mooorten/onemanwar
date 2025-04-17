using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;                 // Hvor hurtigt spilleren bevæger sig
    public GameObject bulletPrefab;              // Bullet prefab der bliver skudt
    public Transform firePoint;                  // Hvor kuglen bliver spawnet fra

    void Update()
    {
        // Bevægelse (A/D eller venstre/højre piletaster)
        float moveX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveX, 0f, 0f) * moveSpeed * Time.deltaTime;

        // Skyd når venstre mus bliver klikket
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}
