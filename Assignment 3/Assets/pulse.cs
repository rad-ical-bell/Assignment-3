using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource audioSource;      
    public int numberOfPrimitives = 100;  
    public float pulseSpeed = 5f;  
    public float scaleFactor = 0.5f; 
    public float startTime = 40f;  
    public float endTime = 46f; 

    private GameObject[] primitives;   
    private float[] spectrum = new float[256]; 
    private bool cubesActive = false; 

    private void Update()
    {
        if (Time.time >= startTime && Time.time <= endTime)
        {
            if (!cubesActive)
            {
                InstantiateCubes();
                cubesActive = true;
            }

            audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

            float bassIntensity = 0f;
            for (int i = 0; i < 5; i++)  
            {
                bassIntensity += spectrum[i];
            }

            foreach (GameObject primitive in primitives)
            {
                float pulse = Mathf.Lerp(1, 1 + bassIntensity * scaleFactor, Mathf.Sin(Time.time * pulseSpeed));
                primitive.transform.localScale = new Vector3(pulse, pulse, pulse); // Apply scale to all axes (X, Y, Z)
            }
        }
        else if (Time.time > endTime && cubesActive)
        {
            DestroyCubes();
            cubesActive = false;
        }
    }

    private void InstantiateCubes()
    {
        primitives = new GameObject[numberOfPrimitives];

        for (int i = 0; i < numberOfPrimitives; i++)
        {
            Vector3 position = new Vector3(Random.Range(-10f, 10f), Random.Range(1f, 5f), Random.Range(-10f, 10f));
            primitives[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            primitives[i].transform.position = position;
        }
    }

    private void DestroyCubes()
    {
        foreach (GameObject primitive in primitives)
        {
            Destroy(primitive);
        }
    }
}

    