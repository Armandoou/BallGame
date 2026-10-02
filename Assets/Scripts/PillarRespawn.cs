using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PillarRespawn : MonoBehaviour
{
    public float fallLimit = -10f;      // altura a la que se considera caído
    public float respawnHeight = 0.5f;  // qué tan arriba reaparece para no quedar dentro de la plataforma

    private Rigidbody rb;
    private Transform root;
    private Vector3 localPos;
    private Quaternion localRot;
    private Vector3 worldPos;
    private Quaternion worldRot;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        root = transform.parent;
        localPos = transform.localPosition;
        localRot = transform.localRotation;
        worldPos = transform.position;
        worldRot = transform.rotation;

        
        transform.SetParent(null);
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

        if (root != null)
        {
            
            transform.position = root.TransformPoint(localPos) + Vector3.up * respawnHeight;
            transform.rotation = root.rotation * localRot;
        }
        else
        {
            transform.position = worldPos + Vector3.up * respawnHeight;
            transform.rotation = worldRot;
        }
    }
}