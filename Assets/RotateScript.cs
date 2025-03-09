using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [Tooltip("Rotation speed in degrees per second")]
    public float rotationSpeed = 10.0f;

    [Tooltip("Whether rotation should be in reverse direction")]
    public bool reverseDirection = false;

    [Tooltip("Axis to rotate around (X = 1,0,0 | Y = 0,1,0 | Z = 0,0,1)")]
    public Vector3 rotationAxis = Vector3.up; // Default to Y-axis rotation

    private void Update()
    {
        // Calculate the rotation amount this frame
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Apply direction modifier
        if (reverseDirection)
        {
            rotationAmount = -rotationAmount;
        }

        // Apply rotation around the specified axis
        transform.Rotate(rotationAxis, rotationAmount, Space.World);
    }
}