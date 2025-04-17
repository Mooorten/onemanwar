using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;                 // Hvor hurtigt spilleren bev�ger sig
    public GameObject bulletPrefab;              // Bullet prefab der bliver skudt
    public Transform firePoint;                  // Hvor kuglen bliver spawnet fra

    void Update()
    {
        // Bev�gelse (A/D eller venstre/h�jre piletaster)
        float moveX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveX, 0f, 0f) * moveSpeed * Time.deltaTime;

        // Skyd n�r venstre mus bliver klikket
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
