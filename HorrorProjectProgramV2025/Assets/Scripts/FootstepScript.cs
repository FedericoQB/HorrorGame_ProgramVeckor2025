using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip[] footstepClips;  // Array of footstep sounds
    public float baseStepInterval = 0.5f; // Base time between steps
    public float minMovementSpeed = 0.1f; // Minimum speed to play footsteps
    public float speedMultiplier = 0.2f; // Factor to adjust step interval with speed

    private AudioSource audioSource;
    private float stepTimer;
    private bool isMoving;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        stepTimer = baseStepInterval;
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
            // Adjust the step interval based on speed
            float dynamicStepInterval = baseStepInterval - (speed * speedMultiplier);
            dynamicStepInterval = Mathf.Clamp(dynamicStepInterval, 0.1f, baseStepInterval); // Prevent too small intervals

            stepTimer -= Time.deltaTime;

            // Play a footstep if the timer runs out
            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = dynamicStepInterval; // Reset timer with adjusted interval
            }
        }
        else
        {
            // Reset timer if not moving
            stepTimer = baseStepInterval;
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
