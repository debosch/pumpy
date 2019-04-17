using UnityEngine;

public class Coin : MonoBehaviour
{
    private float coinLifeTime = 5f;

    private void Update()
    {
        coinLifeTime -= Time.deltaTime;

        if (coinLifeTime < 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerLifeTime.LifeTime += 2f;
            Destroy(gameObject);
        }
    }
}
