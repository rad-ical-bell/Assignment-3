using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveAmount = .4f;
    public float speed = 2f;

    private bool moveComplete = false;

    private bool rotateComplete = false;

    void Update()
    {
        if (!moveComplete)
        {
            if (transform.position.y < 1f)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up * 4, Time.deltaTime * 2);
            }
            else
            {
                moveComplete = true;
            }
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(-90f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * speed * 100f);
        }
    }
}
