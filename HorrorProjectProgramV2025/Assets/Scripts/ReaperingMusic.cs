using UnityEngine;

public class ToggleableLightActivator : MonoBehaviour
{
    public Light lightToToggle; // The light to toggle
    public AudioClip toggleSound; // The sound to play on toggle
    private AudioSource audioSource; // The audio source to play the sound

    void Start()
    {
        if (lightToToggle == null)
        {
            Debug.LogError("No light assigned!");
            return;
        }

        // Add and configure an AudioSource if none exists
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = toggleSound;
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lightToToggle.enabled = !lightToToggle.enabled; // Toggle the light
            if (toggleSound != null)
                audioSource.Play(); // Play the toggle sound
        }
    }
}
