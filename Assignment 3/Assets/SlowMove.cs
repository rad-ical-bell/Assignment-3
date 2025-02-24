using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMove : MonoBehaviour
{
    public Light directionalLight;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public Quaternion startRotation;
    public Quaternion endRotation;

    public float flashInterval = 0.1f;
    public float flashIntensity = 0.2f;

    private float timePassed;
    private float flashTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        directionalLight.transform.position = startPosition;
        directionalLight.transform.rotation = startRotation;
        directionalLight.intensity = flashIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed = Timer.time;

        if (timePassed < 7f)
        {
            float lerpFactor = timePassed / 7f;
            directionalLight.transform.position = Vector3.Lerp(startPosition, endPosition, lerpFactor);
            directionalLight.transform.rotation = Quaternion.Lerp(startRotation, endRotation, lerpFactor);
        }
        else if (timePassed >= 7 && timePassed <= 9f)
        {
            Flashing();
        }
        else
        {
            directionalLight.intensity = flashIntensity;
        }
    }

    void Flashing()
    {
        flashTime += Time.deltaTime;

        if (flashTime >= flashInterval)
        {
            directionalLight.intensity = directionalLight.intensity == 0f ? flashIntensity : 0f;
            flashTime = 0f;  
        }
    }
}
