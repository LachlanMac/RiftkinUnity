using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [Tooltip("Maximum distance from the origin that the object can move")]
    public float radius = 5.0f;

    [Tooltip("Movement speed in units per second")]
    public float speed = 1.0f;

    [Tooltip("Minimum distance threshold to consider a point reached")]
    public float arrivalThreshold = 0.1f;

    // The origin point around which movement occurs
    private Vector3 origin;

    // The current target position
    private Vector3 targetPosition;

    private void Start()
    {
        // Store the initial position as the origin
        origin = transform.position;

        // Set the first random target
        PickNewTarget();
    }

    private void Update()
    {
        // Move toward the target position
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        // Check if we've reached the target (or close enough)
        if (Vector3.Distance(transform.position, targetPosition) < arrivalThreshold)
        {
            PickNewTarget();
        }
    }

    private void PickNewTarget()
    {
        // Generate a random direction
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        // Generate a random distance within the radius
        float randomDistance = Random.Range(0, radius);

        // Combine direction and distance for the new target
        Vector3 randomOffset = new Vector3(
            randomDirection.x * randomDistance,
            randomDirection.y * randomDistance,
            0 // Keeping Z constant for 2D movement
        );

        // Set the new target position relative to the origin
        targetPosition = origin + randomOffset;
    }

    // Optional: Draw the movement boundary in the editor
    private void OnDrawGizmosSelected()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(origin, radius);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, targetPosition);
        }
    }
}