using UnityEngine;
using System.Collections;

public class Saw : MonoBehaviour
{
    private readonly float rotationSpeed = 1000f;

    private AudioSource sawSound;

    //Sound duration
    private readonly float waitTime = 1.658f;

    [SerializeField] private AudioClip sound;
    [SerializeField] private AudioClip killSound;

    private void Start()
    {
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
        if (collision.tag.Equals("Player"))
            PlayerControl.Instance.Alive = false;

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
