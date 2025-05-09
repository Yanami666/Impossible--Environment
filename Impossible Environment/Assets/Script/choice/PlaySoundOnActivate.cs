using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundOnActivate : MonoBehaviour
{
    private AudioSource audioSource;
    private bool wasActive = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        wasActive = gameObject.activeSelf;
    }

    void Update()
    {
        // Detect transition from inactive ➜ active
        if (!wasActive && gameObject.activeSelf)
        {
            audioSource.Play();
        }

        wasActive = gameObject.activeSelf;
    }
}