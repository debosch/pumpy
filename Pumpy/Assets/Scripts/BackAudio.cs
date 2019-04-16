using UnityEngine;

public class BackAudio : MonoBehaviour
{

    private AudioSource main;

    void Start()
    {
        main = GetComponent<AudioSource>();
        main.Play();
    }

    void Update()
    {
        if (!PlayerControl.Instance.Alive)
            main.Stop();
    }
}
