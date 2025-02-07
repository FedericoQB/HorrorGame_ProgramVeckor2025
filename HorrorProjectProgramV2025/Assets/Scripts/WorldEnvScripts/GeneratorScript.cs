using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public static bool isGeneratorOn = false;
    bool isOffCompletely = false;

    public GameObject lightSource;
    public GameObject lightSourceRoom;

    public GameObject generatorLamp;
    public GameObject generatorLampState2;

    public GameObject lockedPowerDoor;
    public GameObject unlockDoor;
    public GameObject sequenceCollider;

    public AudioClip poweredUpSound; // Sound to play when generator is powered up
    private AudioSource audioSource; // AudioSource to play the sound

    // Start is called before the first frame update
    void Start()
    {
        // Add an AudioSource component if not already present
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false; // Ensure it doesn't play immediately when the scene starts
    }

    // Update is called once per frame
    void Update()
    {
        if (isGeneratorOn && !isOffCompletely)
        {
            // Activate the light sources and sequence collider
            lightSource.SetActive(true);
            lightSourceRoom.SetActive(true);
            sequenceCollider.SetActive(true);
            generatorLamp.SetActive(false);
            generatorLampState2.SetActive(true);

            unlockDoor.GetComponent<DoorScript>().isLocked = false;

            // Play powered-up sound if it's assigned
            if (poweredUpSound != null && !audioSource.isPlaying)
            {
                audioSource.clip = poweredUpSound;
                audioSource.Play();
            }

            // Set the flag to prevent the generator from powering up again
            isOffCompletely = true;

            // You can also add additional logic for locked doors here
            // Add functioning power door, e.g., unlock the door
            lockedPowerDoor.SetActive(false); // Assuming door gets unlocked when generator is on
        }
    }
}
