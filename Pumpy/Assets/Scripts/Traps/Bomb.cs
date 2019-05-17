using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    [SerializeField] private AudioClip timerSound;
    [SerializeField] private Transform explosion;
    [SerializeField] private LayerMask whatToHit;

    private AudioSource audioSrc;
    private Animator animator;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();       

        audioSrc.clip = timerSound;
        audioSrc.Play();

        StartCoroutine(Explosion());
    }

    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(Random.Range(1f,2f));
        audioSrc.Stop();

        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
