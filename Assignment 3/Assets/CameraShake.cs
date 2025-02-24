using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public AudioSource audioSource;
    public float shakeIntensity = 0.1f;
    private float shakeDuration = 5f;

    public float currentShakeTimer = 20f;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (currentShakeTimer > 0)
        {
            float shakeAmount = audioSource.volume * shakeIntensity;
            Vector3 offset = new Vector3(Random.Range(-shakeAmount, shakeAmount), Random.Range(-shakeAmount, shakeAmount), 0f);
            transform.position = originalPosition + offset;
            currentShakeTimer -= Time.deltaTime;
        }
    }

    public void StartShake()
    {
        currentShakeTimer = shakeDuration;
    }

}
