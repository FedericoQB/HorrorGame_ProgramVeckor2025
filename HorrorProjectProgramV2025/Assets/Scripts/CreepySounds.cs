using System.Collections;
using UnityEngine;

public class RandomCreepySounds : MonoBehaviour
{
    public AudioClip[] creepySounds;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on " + gameObject.name);
        }

        if (creepySounds.Length == 0)
        {
            Debug.LogError("No creepy sounds assigned!");
        }

        StartCoroutine(PlayRandomCreepySound());
    }

    IEnumerator PlayRandomCreepySound()
    {
        while (true)
        {
            float randomDelay = Random.Range(10f, 30f); // Random delay
            Debug.Log("Waiting for " + randomDelay + " seconds before playing a sound...");
            yield return new WaitForSeconds(randomDelay);

            if (creepySounds.Length > 0)
            {
                AudioClip randomClip = creepySounds[Random.Range(0, creepySounds.Length)];
                Debug.Log("Playing sound: " + randomClip.name);
                audioSource.PlayOneShot(randomClip);
            }
        }
    }
}
