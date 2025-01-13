using UnityEngine;
using System.Collections;

public class MonsterScreamer : MonoBehaviour
{
    public AudioClip[] screamSounds; // Array of different scream sounds
    private AudioSource audioSource; // AudioSource to play the screams
    public float minTimeBetweenScreams = 2f; // Minimum time between screams
    public float maxTimeBetweenScreams = 5f; // Maximum time between screams

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

        // Start the coroutine to scream at random intervals
        StartCoroutine(ScreamAtRandomTimes());
    }

    private IEnumerator ScreamAtRandomTimes()
    {
        while (true)
        {
            // Wait for a random amount of time before screaming
            float randomTime = Random.Range(minTimeBetweenScreams, maxTimeBetweenScreams);
            yield return new WaitForSeconds(randomTime);

            // Pick a random scream sound from the array
            AudioClip selectedScream = screamSounds[Random.Range(0, screamSounds.Length)];

            // Play the selected scream
            audioSource.clip = selectedScream;
            audioSource.Play();
        }
    }
}
