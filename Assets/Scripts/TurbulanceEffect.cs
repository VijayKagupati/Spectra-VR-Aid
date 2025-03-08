using UnityEngine;

public class TurbulenceEffect : MonoBehaviour
{
    public float turbulenceIntensity = 1.0f;  // Increased intensity for stronger turbulence
    public float turbulenceSpeed = 1.0f;      // Speed of the turbulence changes
    public float positionMultiplier = 0.2f;   // Multiplier for positional turbulence
    public float rotationMultiplier = 1.0f;   // Multiplier for rotational turbulence

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        // Save the original position and rotation of the airplane
        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        // Generate more random and varying noise values for turbulence
        float noiseX = (Mathf.PerlinNoise(Time.time * turbulenceSpeed, 0.0f) - 0.5f) * 2.0f;
        float noiseY = (Mathf.PerlinNoise(0.0f, Time.time * turbulenceSpeed) - 0.5f) * 2.0f;
        float noiseZ = (Mathf.PerlinNoise(Time.time * turbulenceSpeed, Time.time * turbulenceSpeed) - 0.5f) * 2.0f;

        // Apply more randomized and stronger rotations to simulate turbulence
        transform.localRotation = originalRotation * Quaternion.Euler(
            noiseX * turbulenceIntensity * rotationMultiplier,
            noiseY * turbulenceIntensity * rotationMultiplier,
            noiseZ * turbulenceIntensity * rotationMultiplier
        );

        // Apply more randomized and stronger movements to simulate turbulence
        transform.localPosition = originalPosition + new Vector3(
            noiseX * turbulenceIntensity * positionMultiplier,
            noiseY * turbulenceIntensity * positionMultiplier,
            noiseZ * turbulenceIntensity * positionMultiplier
        );
    }
}
