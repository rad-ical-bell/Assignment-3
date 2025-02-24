using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerp : MonoBehaviour
{
    GameObject[] spheres;
    static int numSphere = 200;
    float timePassed;
    Vector3[] initPos;
    Vector3[] startPosition, endPosition;
    float lerpFraction;
    float t;
    float speed = 5f;

    public AudioSource audioSource; 
    private float[] audioSpectrum; 

    void Start()
    {
        spheres = new GameObject[numSphere];
        initPos = new Vector3[numSphere];
        startPosition = new Vector3[numSphere];
        endPosition = new Vector3[numSphere];
        audioSpectrum = new float[256]; 

        for (int i = 0; i < numSphere; i++)
        {
            float r = 10f;
            startPosition[i] = new Vector3(r * speed* Random.Range(-1f, 1f), r * speed * Random.Range(-1f, 1f), r * Random.Range(-1f, 1f));

            r = 3f;
            endPosition[i] = new Vector3(r * speed * Random.Range(-1f, 1f), r * speed * Random.Range(-1f, 1f), r * Random.Range(-1f, 1f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        timePassed = Timer.time;
        audioSource.GetSpectrumData(audioSpectrum, 0, FFTWindow.Hanning); 

        if (timePassed >= 15f && timePassed <= 31f)
        {
            if (spheres[0] == null)
            {
                for (int i = 0; i < numSphere; i++)
                {
                    spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    initPos[i] = startPosition[i];
                    spheres[i].transform.position = initPos[i];

                    Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();
                    float hue = (float)i / numSphere;
                    Color color = Color.HSVToRGB(hue, 0.5f, .08f);
                    sphereRenderer.material.color = color;
                }
            }

            for (int i = 0; i < numSphere; i++)
            {
                lerpFraction = Mathf.Sin(timePassed) * 0.5f + 0.5f;
                t = i * 2 * Mathf.PI / numSphere;

                spheres[i].transform.position = Vector3.Lerp(startPosition[i], endPosition[i], lerpFraction);
                Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();
                
                float amplitude = audioSpectrum[i % audioSpectrum.Length];  
                float hue = Mathf.Abs(Mathf.Sin(timePassed * 2f + i * 0.1f)); 
                float saturation = Mathf.Clamp(amplitude * 2f, 0f, 1f); 
                float brightness = Mathf.Clamp(1 - amplitude, 0.4f, 1f);
                Color color = Color.HSVToRGB(hue, saturation, brightness); 
                sphereRenderer.material.color = color;
            }
        }

        if (timePassed > 31f && timePassed <= 39)
        {
            for (int i = 0; i < numSphere; i++)
            {
                Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();
                Color color = Color.HSVToRGB(0.1f + (i / 3f), 0f + (i / 2f), 0.2f); 
                sphereRenderer.material.color = color;
            }
        }

        if (timePassed > 40f)
        {
            for (int i = 0; i < numSphere; i++)
            {
                if (spheres[i] != null)
                {
                    Destroy(spheres[i]);
                    spheres[i] = null; 
                }
            }
        }
    }
}
