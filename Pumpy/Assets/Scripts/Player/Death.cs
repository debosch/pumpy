using UnityEngine;

public class Death : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10,10), Random.Range(-10, 3)));
    }
}
