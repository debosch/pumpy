using UnityEngine;
using System.Collections;

public class Saw : MonoBehaviour
{
    //Shake constants
    private readonly float duration = 0.4f;
    private readonly float magnitude = 0.1f;
    private readonly float rotationMagnitude = 0.5f;

    //Shake
    [SerializeField] private Transform cameraRef;
    private Shaker shaker; 

    private readonly float rotationSpeed = 1000f;

    private AudioSource sawSound;

    //Sound duration
    private readonly float waitTime = 1.658f;

    //Sounds
    [SerializeField] private AudioClip sound;
    [SerializeField] private AudioClip killSound;

    private void Start()
    {
        shaker = GetComponent<Shaker>();
        sawSound = GetComponent<AudioSource>();
        sawSound.clip = sound;
        sawSound.Play();
    }

    private void Update()
    {
        transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            PlayerControl.Instance.Alive = false;

        StartCoroutine(shaker.Shake(cameraRef, duration, magnitude, rotationMagnitude));
        StartCoroutine(ActivateSawSound());
    }

    private IEnumerator ActivateSawSound()
    {
        sawSound.clip = killSound;
        sawSound.Play();
        yield return new WaitForSeconds(waitTime);
        sawSound.clip = sound;
        sawSound.Play();
    }
}
