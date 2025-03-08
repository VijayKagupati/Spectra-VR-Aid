using System.Collections;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    // Assign the GameObjects for the signals in the Unity Inspector
    public GameObject greenSignal;
    public GameObject yellowSignal;
    public GameObject redSignal;

    private void Start()
    {
        // Start the coroutine to handle the signal transitions
        StartCoroutine(TrafficLightSequence());
    }

    private IEnumerator TrafficLightSequence()
    {
        // Wait for 5 seconds before starting the transition
        yield return new WaitForSeconds(5f);

        // Turn off green signal, turn on yellow signal
        greenSignal.SetActive(false);
        yellowSignal.SetActive(true);

        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Turn off yellow signal, turn on red signal
        yellowSignal.SetActive(false);
        redSignal.SetActive(true);
    }
}
