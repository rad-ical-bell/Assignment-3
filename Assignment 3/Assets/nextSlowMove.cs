using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextSlowMove : MonoBehaviour
{
    public Light directionalLight;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public Quaternion startRotation;
    public Quaternion endRotation;


    private float timePassed;

    // Start is called before the first frame update
    void Start()
    {
        directionalLight.transform.position = startPosition;
        directionalLight.transform.rotation = startRotation;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed = Timer.time;

        if (timePassed < 8f)
        {
            float lerpFactor = timePassed / 8f;
            directionalLight.transform.position = Vector3.Lerp(startPosition, endPosition, lerpFactor);
            directionalLight.transform.rotation = Quaternion.Lerp(startRotation, endRotation, lerpFactor);
        }
    }

    // void Flashing()
    // {
    //     flashTime += Time.deltaTime;

    //     if (flashTime >= flashInterval)
    //     {
    //         directionalLight.intensity = directionalLight.intensity == 0f ? flashIntensity : 0f;
    //         flashTime = 0f;  
    //     }
    // }
}

