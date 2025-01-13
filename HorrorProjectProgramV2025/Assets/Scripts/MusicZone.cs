using UnityEngine;
using Game.Audio; // Namespace where your SoundManager resides

public class MusicZone : MonoBehaviour
{
    public AudioClip zoneMusic; // Assign the music for this area in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        print("inne i trigger ej 2d");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("inne i trigger");
        // Check if the player enters the area
        if (other.CompareTag("Player"))
        {
            print("inne i player trigger");
            SoundManager.Instance.PlayMusic(zoneMusic);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Stop the music when the player exits the area (optional)
        if (other.CompareTag("Player"))
        {
            SoundManager.Instance.StopMusic();
        }
    }
}
