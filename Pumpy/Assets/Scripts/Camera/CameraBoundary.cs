using UnityEngine;

public class CameraBoundary : MonoBehaviour
{
    private readonly float minX = -7.74f, minY = 0, maxY = 1.11f, maxX = 6.19f;

    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z);
    }
}
