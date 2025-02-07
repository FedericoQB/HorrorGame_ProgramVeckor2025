using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip[] footstepClips;  // Array of footstep sounds
    public float baseStepInterval = 0.5f; // Default time between steps
    public float speedMultiplier = 1.0f; // Adjust interval based on speed
    public float minMovementSpeed = 0.1f; // Minimum speed to trigger footsteps

    private AudioSource audioSource;
    private float stepTimer;
    private float stepInterval;
    private CharacterController characterController;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
        stepInterval = baseStepInterval;
        stepTimer = stepInterval;
    }

    void Update()
    {
        // Get player's velocity or movement input
        Vector3 velocity = characterController ? characterController.velocity : new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float speed = velocity.magnitude;

        // Check if the player is moving above the minimum speed
        bool isMoving = speed > minMovementSpeed;

        if (isMoving)
        {
            // Dynamically adjust step interval based on player speed
            stepInterval = baseStepInterval / Mathf.Clamp(speed * speedMultiplier, 1f, 3f);

            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            // Reset timer when not moving
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
