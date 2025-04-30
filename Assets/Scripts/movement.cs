using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = .5f;
    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(-zDirection, 0.0f, xDirection);

        transform.position += moveDirection * speed;
    }
}
