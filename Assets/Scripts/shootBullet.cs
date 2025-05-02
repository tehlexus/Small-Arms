using Unity.VisualScripting;
using UnityEngine;

public class shootBullet : MonoBehaviour
{
    public GameObject projectile;
    private float launchVelocity = 10f;
    private int maxBullets = 2;
    private int currentBullets = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentBullets < maxBullets)
        {
            // Instantiate the bullet and fire it
            GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = transform.forward * launchVelocity;
            }

            // Increase the active bullet count
            currentBullets++;

            // Add a listener to decrease the active bullet count when the bullet is destroyed
            BulletBounce bulletScript = bullet.GetComponent<BulletBounce>();
            if (bulletScript != null)
            {
                bulletScript.OnDestroyed += () => currentBullets--;
            }
        }
    }
}
