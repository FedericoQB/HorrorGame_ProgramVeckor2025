using UnityEngine;
using Game.Audio; // Namespace where your SoundManager resides

public class MusicZone : MonoBehaviour
{
    public AudioClip zoneMusic; // Assign the music for this area in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the area
        if (other.CompareTag("Player"))
        {
            SoundManager.Instance.PlayMusic(zoneMusic);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Stop the music when the player exits the area (optional)
        if (other.CompareTag("Player"))
        {
            SoundManager.Instance.StopMusic();
        }
    }
}
