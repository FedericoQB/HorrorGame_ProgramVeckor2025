using System.Collections;
using UnityEngine;

public class RandomCreepySounds : MonoBehaviour
{
    public AudioClip[] creepySounds;  // Array to store creepy sound clips
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomCreepySound());
    }

    IEnumerator PlayRandomCreepySound()
    {
        while (true)
        {
            float randomDelay = Random.Range(10f, 60f); // Random delay between 10 and 60 seconds
            yield return new WaitForSeconds(randomDelay);

            if (creepySounds.Length > 0)
            {
                AudioClip randomClip = creepySounds[Random.Range(0, creepySounds.Length)];
                audioSource.PlayOneShot(randomClip);
            }
        }
    }
}
