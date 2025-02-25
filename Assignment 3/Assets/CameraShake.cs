using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public AudioSource audioSource;
    public float shakeIntensity = 0.1f;

    public float currentShakeTimer = 20f;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        float timePassed = Timer.time;

        if ((timePassed >= 78f && timePassed <= 79f) || 
            (timePassed >= 84f && timePassed <= 86f) || 
            (timePassed >= 89f && timePassed <= 91f))
        {
            if (currentShakeTimer > 0)
            {
                float shakeAmount = audioSource.volume * shakeIntensity;
                Vector3 offset = new Vector3(Random.Range(-shakeAmount, shakeAmount), Random.Range(-shakeAmount, shakeAmount), 0f);
                transform.position = originalPosition + offset;
                currentShakeTimer -= Time.deltaTime;
            }
        }
    }

}
