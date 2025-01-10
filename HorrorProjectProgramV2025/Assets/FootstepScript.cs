using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip[] footstepClips; // Array of footstep sounds
    public float stepInterval = 0.5f; // Time between steps
    public float minMovementSpeed = 0.1f; // Minimum speed to play footsteps

    private AudioSource audioSource;
    private float stepTimer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        stepTimer = stepInterval;
    }

    void Update()
    {
        // Get player's velocity or movement input (example uses Input system)
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float speed = movement.magnitude;

        // Only play footsteps if the player is moving
        if (speed > minMovementSpeed)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            // Reset the timer when not moving
            stepTimer = stepInterval;
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
