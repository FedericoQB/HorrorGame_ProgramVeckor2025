using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ReusableMusicTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip musicClip; // The music clip to play
    public bool playOnEnter = true; // If true, music will play when entering the trigger
    public bool stopOnExit = false; // If true, music will stop when exiting the trigger

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false; // You can set this to true if you want looping music
        audioSource.playOnAwake = false; // Prevent music from starting automatically
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        print("something entered");
        print(other.tag);
        if (other.CompareTag("Player") && playOnEnter)
        {
            if (musicClip != null)
            {
                print("playing music");
                audioSource.clip = musicClip;
                audioSource.PlayOneShot(musicClip);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        print("something exited");
        if (other.CompareTag("Player") && stopOnExit)
        {
            print("stopping muisc");
            audioSource.Stop();
        }
    }
}
