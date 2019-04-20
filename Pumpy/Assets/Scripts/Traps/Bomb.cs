using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    [SerializeField] private AudioClip timerSound;
    [SerializeField] private Transform explosion;

    private AudioSource audioSrc;
    private Animator animator;

    private readonly float timerSoundTime = 1.817f;

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
        yield return new WaitForSeconds(timerSoundTime);

        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
