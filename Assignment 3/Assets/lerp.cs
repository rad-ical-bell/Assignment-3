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
            startPosition[i] = new Vector3(r * Random.Range(-1f, 1f), r * Random.Range(-1f, 1f), r * Random.Range(-1f, 1f));

            r = 3f;
            endPosition[i] = new Vector3(r * Random.Range(-1f, 1f), r * Random.Range(-1f, 1f), r * Random.Range(-1f, 1f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        timePassed = Timer.time;
        audioSource.GetSpectrumData(audioSpectrum, 0, FFTWindow.Hanning); 

        if (timePassed >= 31f && timePassed <= 38f)
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
                    Color color = Color.HSVToRGB(hue, 1f, 1f);
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
                
                float scaleMultiplier = Mathf.Lerp(0.1f, 2f, amplitude); 
                spheres[i].transform.localScale = new Vector3(scaleMultiplier, scaleMultiplier, scaleMultiplier);

                float hue = Mathf.Abs(Mathf.Sin(timePassed * 0.5f + i * 0.1f)); 
                float saturation = Mathf.Clamp(amplitude * 2f, 0f, 1f); 
                Color color = Color.HSVToRGB(hue, saturation, 1f); 
                sphereRenderer.material.color = color;
            }
        }

        if (timePassed > 38f)
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
