using UnityEngine;

public class PlayAudioOnProximity : MonoBehaviour
{
    public AudioClip goodjobClip;  // Assign the "goodjob" audio clip in the Inspector
    public float triggerRadius = 5f;  // Radius within which the audio will play
    public GameObject targetObject;  // Assign the target GameObject to track in the Inspector
    private AudioSource audioSource;
    private bool hasPlayed = false;  // Tracks if the audio has already been played

    void Start()
    {
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();

        // Check if the target object is assigned
        if (targetObject == null)
        {
            Debug.LogError("Target object not assigned! Please assign a target GameObject in the Inspector.");
        }
    }

    void Update()
    {
        if (targetObject != null && !hasPlayed)
        {
            // Calculate the distance between the target object and the GameObject
            float distanceToTarget = Vector3.Distance(targetObject.transform.position, transform.position);

            // If the target object is within the trigger radius and the audio hasn't been played yet
            if (distanceToTarget <= triggerRadius)
            {
                // Play the "goodjob" audio clip
                audioSource.PlayOneShot(goodjobClip);
                hasPlayed = true;  // Set the flag to true to prevent replaying the audio
            }
        }
    }
}
