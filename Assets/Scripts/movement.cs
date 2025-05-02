using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 500f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(-zDirection, 0.0f, xDirection).normalized;

        rb.linearVelocity = moveDirection * speed * Time.fixedDeltaTime;
    }
}
