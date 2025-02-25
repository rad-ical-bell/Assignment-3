using UnityEngine;

public class SpiralMovement : MonoBehaviour
{
    public float rotationSpeed = 10f;      // Speed of rotation
    public float spiralSpeed = 2f;         // Speed of the spiral movement
    public float spiralRadius = 5f;        // Radius of the spiral
    public float heightSpeed = 1f;         // Speed at which the object rises or falls

    private float angle = 0f;              // Starting angle

    void Update()
    {
        // Update the angle over time for the spiral effect
        angle += spiralSpeed * Time.deltaTime;

        // Calculate the new x and z positions for the spiral (circular motion)
        float x = Mathf.Cos(angle) * spiralRadius;
        float z = Mathf.Sin(angle) * spiralRadius;

        // Move the object in the spiral path (y position increases as the spiral progresses)
        transform.position = new Vector3(x, transform.position.y + heightSpeed * Time.deltaTime, z);

        // Rotate the object continuously (spin effect)
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
