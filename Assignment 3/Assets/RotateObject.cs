using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float startTransitionTime = 46f; 
    public Vector3 targetPosition = new Vector3(1.3f, 2.54f, -7.63f);
    public Vector3 targetRotation = new Vector3(41f, -56f, -82f); 
    public bool checkPos = false; 

    void Update()
    {
        if (Time.time >= startTransitionTime && !checkPos) 
        {
            transform.position = targetPosition;
            transform.rotation = Quaternion.Euler(targetRotation);
            checkPos = true; 
        }

        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
