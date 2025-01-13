using UnityEngine;

public class MonsterScreamer : MonoBehaviour
{
    public AudioClip[] screamSounds; // Array of different scream sounds
    private AudioSource audioSource; // AudioSource to play the screams

    void Start()
    {
        if (screamSounds == null || screamSounds.Length == 0)
        {
            Debug.LogError("No scream sounds assigned!");
            return;
        }

        // Add and configure an AudioSource if none exists
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // Ensure no sound plays at start
    }

    public void Scream()
    {
        if (screamSounds.Length > 0)
        {
            // Pick a random scream sound from the array
            AudioClip selectedScream = screamSounds[Random.Range(0, screamSounds.Length)];

            // Play the selected scream
            audioSource.clip = selectedScream;
            audioSource.Play();
        }
    }
}
