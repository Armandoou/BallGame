using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformTilt : MonoBehaviour
{
    public float interval = 4f;     
    public float maxAngle = 15f;    
    public float tiltSpeed = 10f;   

    private Rigidbody rb;
    private Quaternion targetRotation;
    private float timer;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        targetRotation = transform.rotation;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;
            PickNewTilt();
        }
    }

    void FixedUpdate()
    {
        Quaternion next = Quaternion.RotateTowards(
            rb.rotation,
            targetRotation,
            tiltSpeed * Time.fixedDeltaTime
        );
        rb.MoveRotation(next);
    }

    void PickNewTilt()
    {
        float x = Random.Range(-maxAngle, maxAngle);
        float z = Random.Range(-maxAngle, maxAngle);
        targetRotation = Quaternion.Euler(x, 0f, z);
    }
}