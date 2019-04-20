using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    private readonly float duration = 0.3f;
    private readonly float magnitude = 0.07f;
    private readonly float rotationMagnitude = 0.3f;
    private readonly float explosionRange = 1.5f;

    private Shaker shaker;
    private AudioSource audioSrc;
    private Transform cameraRef;

    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        cameraRef = GameObject.FindGameObjectWithTag("MainCamera").transform;

        shaker = GetComponent<Shaker>();
        audioSrc = GetComponent<AudioSource>();
        
        audioSrc.Play();

        ExplosionKill();

        StartCoroutine(shaker.Shake(cameraRef, duration, magnitude, rotationMagnitude));
    }

    private void ExplosionKill()
    {
        if (Vector2.Distance(target.position, transform.position) <= explosionRange && 
            target.CompareTag("Player") && target != null)
        {
            PlayerControl.Instance.Alive = false;
        }
    }

    // For animation behaviour
    private void DestroyItSelf()
    {
        Destroy(gameObject);
    }
}
