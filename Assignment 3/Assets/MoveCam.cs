using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Camera cam;
    private Vector3 startPosition = new Vector3(-3.3f, 0.1f, 8.2f);
    private Vector3 endPosition = new Vector3(-5.3f, -17.6f, 41.5f);
    private Quaternion startRotation = Quaternion.Euler(-0.067f, -220.9f, -0.0676f);
    private Quaternion endRotation = Quaternion.Euler(-20.26f, -545.3f, 34.64f);

    private Vector3 newPosition = new Vector3(7.4f, 8.4f, 14.9f);
    private Quaternion newRotation = Quaternion.Euler(-30.94f, -178.63f, -25.82f);

    private Vector3 newestPosition = new Vector3(10.5f, 2.2f, -1.7f);
    private Quaternion newestRotation = Quaternion.Euler(0.018f, -95.32f, -35.27f);
    

    public float flashInterval = 0.1f;
    public float flashIntensity = 0.2f;

    private float timePassed;
    private float flashTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        cam.transform.position = startPosition;
        cam.transform.rotation = startRotation;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed = Timer.time;

        if (timePassed >= 15f && timePassed <= 25f)
        {
            float lerpFactor = (timePassed - 15f)/ 10f;
            cam.transform.position = Vector3.Lerp(startPosition, endPosition, lerpFactor);
            cam.transform.rotation = Quaternion.Lerp(startRotation, endRotation, lerpFactor);
        }
        
        if (timePassed > 25f && timePassed <= 35f) 
        {
            float lerpFactor = (timePassed - 25f)/ 10f;
            cam.transform.position = Vector3.Lerp(endPosition, newPosition, lerpFactor);
            cam.transform.rotation = Quaternion.Lerp(endRotation, newRotation, lerpFactor);
        }
        if (timePassed > 39f && timePassed <= 46f)
        {
            float lerpFactor = (timePassed - 39f)/ 7f;
            cam.transform.position = Vector3.Lerp(newPosition, newestPosition, lerpFactor);
            cam.transform.rotation = Quaternion.Lerp(newRotation, newestRotation, lerpFactor);
        
        }
    }
}

