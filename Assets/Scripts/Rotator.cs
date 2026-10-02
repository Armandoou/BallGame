using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 speed = new Vector3(0, 90, 0);

    void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
    }
}