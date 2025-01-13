using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip[] footstepClips;  // Array of footstep sounds
    public float stepInterval = 0.5f; // Time between steps
    public float minMovementSpeed = 0.1f; // Minimum speed to play footsteps

    private AudioSource audioSource;
    private float stepTimer;
    private bool isMoving;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        stepTimer = stepInterval;
    }

    void Update()
    {
        // Get player's velocity or movement input
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float speed = movement.magnitude;

        // Check if the player is moving
        isMoving = speed > minMovementSpeed;

        if (isMoving)
        {
            stepTimer -= Time.deltaTime;

            // Play a footstep if the timer runs out
            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            // Reset timer and stop the sound if not moving
            stepTimer = stepInterval;
            audioSource.Stop();
        }
    }

    void PlayFootstep()
    {
        if (footstepClips.Length > 0)
        {
            // Pick a random footstep clip
            AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
}
