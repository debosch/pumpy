using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    private float coinLifeTime = 5f;

    private AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

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
            PlayerLifeTime.LifeTime += 3f;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            sound.Play();
        }
    }

}
