using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private enum Moving
    {
        AlongX,
        AlongY
    }

    [SerializeField] private Moving direction;
    [SerializeField] private float highestPoint;
    [SerializeField] private float lowestPoint;
    [SerializeField] private float leftPoint;
    [SerializeField] private float rightPoint;

    private readonly float speed = 100f;

    private bool movingUp = true;
    private bool movingRight = true;

    private Rigidbody2D rb;

    private void Start()
    {       
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (direction == Moving.AlongY)
        {
            if (transform.position.y >= highestPoint)
                movingUp = false;
            else if (transform.position.y <= lowestPoint)
                movingUp = true;

            rb.velocity = movingUp ? Vector2.up * Time.deltaTime * speed : Vector2.down * Time.deltaTime * speed;
        }
        else
        {
            if (transform.position.x >= rightPoint)
                movingRight = false;
            else if (transform.position.x <= leftPoint)
                movingRight = true;

            rb.velocity = movingRight ? Vector2.right * Time.deltaTime * speed : Vector2.left * Time.deltaTime * speed;
        }
    }
}
