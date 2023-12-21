using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public LayerMask targetLayer;
    public float shootingInterval = 1.5f; // Time between shots
    public float detectionRange = 10f; // Range for detecting the player
    private Transform player;
    private bool isPlayerDetected = false;
    private float shootingTimer = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        DetectPlayer();

        if (isPlayerDetected)
        {
            shootingTimer += Time.deltaTime;

            if (shootingTimer >= shootingInterval)
            {
                Shoot();
                shootingTimer = 0f;
            }
        }
    }

    void DetectPlayer()
    {
        RaycastHit hit;
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        if (Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRange, targetLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                isPlayerDetected = true;
            }
            else
            {
                isPlayerDetected = false;
            }
        }
        else
        {
            isPlayerDetected = false;
        }

        Debug.DrawRay(transform.position, directionToPlayer * detectionRange, Color.red); // Visualize the raycast
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity); // No rotation initially
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            Vector3 direction = (player.position - firePoint.position).normalized;
            bulletRb.velocity = direction * bulletSpeed; // Set the velocity in the direction of the player
        }

        Destroy(bullet, 2f); // Destroy the bullet after 2 seconds if it doesn't hit anything
    }
}
