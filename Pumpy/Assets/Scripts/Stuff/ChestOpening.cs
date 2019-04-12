using UnityEngine;

public class ChestOpening : MonoBehaviour
{
    private Animator animator;

    private AudioSource audioSrc;

    private bool opened = false;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && !opened)
        {
            audioSrc.Play();
            animator.SetTrigger("OpenChest");
            opened = true;
        }
    }

}
