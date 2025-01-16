using UnityEngine;

public class HeartbeatSound : MonoBehaviour
{
    public AudioClip heartbeatClip; // Heartbeat sound clip
    public float maxVolume = 1f;   // Maximum volume of the heartbeat sound
    public float fadeDistance = 5f; // Distance within which the sound fades in
    public Transform player;       // Reference to the player

    private AudioSource audioSource;
    private bool isPlayerNear = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = heartbeatClip;
        audioSource.loop = true; // Loop the heartbeat sound
    }

    void Update()
    {
        if (isPlayerNear)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            float volume = Mathf.Clamp01(1 - (distance / fadeDistance)) * maxVolume;
            audioSource.volume = volume;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            audioSource.Stop();
        }
    }
}
