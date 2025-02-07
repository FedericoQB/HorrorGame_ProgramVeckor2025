using UnityEngine;

public class OneTimeLightActivator : MonoBehaviour
{
    public Light lightToActivate; // The light to activate
    public AudioClip activationSound; // The sound to play when activated
    private AudioSource audioSource; // The audio source to play the sound
    private bool hasActivated = false; // Ensure activation happens only once

    void Start()
    {
        if (lightToActivate == null)
        {
            Debug.LogError("No light assigned!");
            return;
        }

        // Add and configure an AudioSource if none exists
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = activationSound;
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasActivated && other.CompareTag("Player"))
        {
            lightToActivate.enabled = true; // Turn on the light
            if (activationSound != null)
                audioSource.Play(); // Play the activation sound
            hasActivated = true; // Prevent further activation
        }
    }
}
