using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{  
    public AudioSource audioSource;
    public Camera camera; 
    private float[] spectrum = new float[256]; 
    private Color targetColor;

    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>(); 

        if (camera == null)
            camera = Camera.main; 

        targetColor = Color.red; 
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        float intensity = 0f;
        for (int i = 0; i < spectrum.Length; i++)
        {
            intensity += spectrum[i];
        }

        intensity /= spectrum.Length;

        if (intensity < 0.05f)
        {
            targetColor = Color.black; 
        }
        else if (intensity < 0.1f)
        {
            targetColor = Color.red; 
        }
        else
        {
            targetColor = Color.white; 
        }

        camera.backgroundColor = Color.Lerp(camera.backgroundColor, targetColor, Time.deltaTime * 2);
    }
}
