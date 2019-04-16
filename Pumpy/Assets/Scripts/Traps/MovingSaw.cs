using UnityEngine;

public class MovingSaw : MonoBehaviour
{
    private Rigidbody2D rb;

    private readonly float rotationSpeed = 1000f;
    [SerializeField] private float speed;

    private bool movingUp = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        if (transform.position.y <= -1.23f)
            movingUp = true;
        else if (transform.position.y >= 0.62f)
            movingUp = false;

        if (movingUp)
            rb.velocity = Vector2.up * speed * Time.deltaTime;
        else
            rb.velocity = Vector2.down * speed * Time.deltaTime;
    }
}

