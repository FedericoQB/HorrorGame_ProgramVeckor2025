using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    public GameObject flashLight;
    public GameObject lightConePivot;
    public GameObject lightCone;
    public AudioClip toggleSound; // Sound for flashlight toggle

    private AudioSource audioSource; // AudioSource to play the toggle sound
    public static bool lightOn = false;
    public static bool enoughBattery;
    Quaternion flashlightAngle = new Quaternion();

    void Start()
    {
        flashLight.SetActive(false);

        // Add or get the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Ensure AudioSource settings are configured
        audioSource.playOnAwake = false; // Don't play on start
    }

    // Update is called once per frame
    void Update()
    {
        // Angle of Flashlight, a 180-degree angle is based in between 0 - 1 on both the z and w axis

        if (Input.GetKey(KeyCode.W))
        {
            flashlightAngle = new Quaternion(0, 0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            flashlightAngle = new Quaternion(0, 0, 1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            flashlightAngle = new Quaternion(0, 0, 0.70711f, -0.70711f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            flashlightAngle = new Quaternion(0, 0, 0.70711f, 0.70711f);
        }

        // Activation of Flashlight
        if (Input.GetKeyDown(KeyCode.F) && lightOn != true && enoughBattery == true)
        {
            flashLight.SetActive(true);
            lightConePivot.SetActive(true);
            lightCone.SetActive(true);
            lightOn = true;

            // Play the toggle sound
            PlayToggleSound();
        }
        else if (Input.GetKeyDown(KeyCode.F) && lightOn == true)
        {
            flashLight.SetActive(false);
            lightConePivot.SetActive(false);
            lightCone.SetActive(false);
            lightOn = false;

            // Play the toggle sound
            PlayToggleSound();
        }

        if (enoughBattery == false)
        {
            flashLight.SetActive(false);
        }

        flashLight.transform.rotation = flashlightAngle;
        lightConePivot.transform.rotation = flashlightAngle;
    }

    // Method to play the toggle sound
    private void PlayToggleSound()
    {
        if (toggleSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(toggleSound);
        }
    }
}
