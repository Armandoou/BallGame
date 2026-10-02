using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallRespawn : MonoBehaviour
{
    public float fallLimit = -10f;   

    private Rigidbody rb;
    private Vector3 startPosition;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.y < fallLimit)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;
    }
}
