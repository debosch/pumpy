using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private readonly float minX = -9.5f, minY = 0, maxY = 1.11f, maxX = 9.6f;

    [SerializeField] private readonly float smoothTimeX = 0.1f;
    [SerializeField] private readonly float smoothTimeY = 0.1f;

    private Vector2 velocity;

    private void FixedUpdate()
    {
        if (target != null)
        {
            float posX = Mathf.SmoothDamp(transform.position.x, target.position.x, ref velocity.x, smoothTimeX);              
            float posY = Mathf.SmoothDamp(transform.position.y, target.position.y, ref velocity.y, smoothTimeY);              

            transform.position = new Vector3(
                Mathf.Clamp(posX, minX, maxX),
                Mathf.Clamp(posY, minY, maxY),
                transform.position.z);
        }
    }
}
