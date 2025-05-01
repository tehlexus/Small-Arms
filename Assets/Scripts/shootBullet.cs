using UnityEngine;

public class shootBullet : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, 0, launchVelocity));
        }
    }
}
