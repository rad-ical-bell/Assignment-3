using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float startTransitionTime = 46f; // Time at which the object will appear
    public Vector3 targetPosition = new Vector3(1.3f, 2.54f, -7.63f); // Target position
    public Vector3 targetRotation = new Vector3(41f, -56f, -82f); // Target rotation
    public bool checkPos = false; // Use `bool` instead of `boolean`

    void Update()
    {
        // Check if the current time is greater than or equal to the startTransitionTime
        if (Time.time >= startTransitionTime && !checkPos) // Corrected negation
        {
            // Set the position and rotation instantly at the 46-second mark
            transform.position = targetPosition;
            transform.rotation = Quaternion.Euler(targetRotation);
            checkPos = true; // Mark that the position has been set
        }

        // Regular rotation
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
