using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private readonly float minX = -9.5f, minY = 0, maxY = 1.11f, maxX = 9.6f;

    void Update()
    {
        if (target != null)
            transform.position = new Vector3(
                Mathf.Clamp(target.position.x, minX, maxX),
                Mathf.Clamp(target.position.y, minY, maxY),
                transform.position.z);
    }
}
