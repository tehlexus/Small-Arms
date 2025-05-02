using System;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBounce : MonoBehaviour
{
    public event Action OnDestroyed;

    public GameObject explosionPrefab;

    Rigidbody rb;
    float speed = 10f;
    int life = 2;

    private Vector3 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = transform.forward;
        rb.linearVelocity = direction * speed;
        rb.freezeRotation = true;
    }

    private void Bounce(Vector3 newDirection)
    {
        direction = newDirection;
        rb.linearVelocity = direction * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        life--;

        if (life < 0 )
        {
            DetachSmoke();

            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
            return;
        }

        ContactPoint firstContact = collision.contacts[0];
        Vector3 reflected = Vector3.Reflect(direction.normalized, firstContact.normal);
        Bounce(reflected);
        transform.rotation = Quaternion.LookRotation(reflected, Vector3.up);
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke();
    }

    private void DetachSmoke()
    {
        foreach (var trail in GetComponentsInChildren<TrailRenderer>())
        {
            trail.transform.parent = null;
            Destroy(trail.gameObject, trail.time);
        }

        foreach (var ps in GetComponentsInChildren<ParticleSystem>())
        {
            if (ps.gameObject != this.gameObject)
            {
                ps.transform.parent = null;
                var main = ps.main;
                main.stopAction = ParticleSystemStopAction.Destroy;
                ps.Stop();
            }
        }
    }
}
