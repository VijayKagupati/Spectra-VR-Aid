using UnityEngine;

public class RoadCrossingController : MonoBehaviour
{
    public GameObject warningLNR;
    public GameObject waitWarning;
    public GameObject greenSignal;
    public AudioClip leftRightClip;
    public GameObject cameraObject; // Reference to the camera object
    public float lookAngleThreshold = 45.0f;

    private bool hasLookedLeft = false;
    private bool hasLookedRight = false;
    private bool hasLooked = false;
    private AudioSource audioSource;
    private Vector3 initialPosition;
    private float timeSinceLastSound = 0f;
    private float soundInterval = 5f; // Sound will play every 5 seconds
    private bool greenSignalActive = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        initialPosition = transform.position; // Store the initial position of the parent object
        CheckGreenSignal(); // Check the state of the green signal at the start
    }

    void Update()
    {
        CheckGreenSignal(); // Continuously check the state of the green signal

        if (greenSignalActive && !hasLooked)
        {
            CheckLookDirection();

            // Prevent movement by resetting the camera's position to the initial position
            cameraObject.transform.position = initialPosition;

            // Play the sound if enough time has passed
            timeSinceLastSound += Time.deltaTime;
            if (timeSinceLastSound >= soundInterval)
            {
                PlayReminderSound();
                timeSinceLastSound = 0f;
            }
        }
        else if (hasLooked)
        {
            warningLNR.SetActive(false);
        }
    }

    void CheckGreenSignal()
    {
        if (greenSignal.activeSelf)
        {
            waitWarning.SetActive(false);
            warningLNR.SetActive(true);
            greenSignalActive = true; // Set the flag to true once the green signal is active
        }
    }

    void CheckLookDirection()
    {
        Vector3 forward = transform.forward;
        Vector3 left = Quaternion.Euler(0, -lookAngleThreshold, 0) * forward;
        Vector3 right = Quaternion.Euler(0, lookAngleThreshold, 0) * forward;

        if (Vector3.Dot(cameraObject.transform.forward, left) > 0.9f)
        {
            hasLookedLeft = true;
        }

        if (Vector3.Dot(cameraObject.transform.forward, right) > 0.9f)
        {
            hasLookedRight = true;
        }

        // If the player has looked both left and right
        if (hasLookedLeft && hasLookedRight)
        {
            hasLooked = true;
        }
    }

    void PlayReminderSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(leftRightClip);
        }
    }
}
