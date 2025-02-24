using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReact : MonoBehaviour
{
    public AudioSource audioSource;
    public Light lightSource;
    public ParticleSystem particleSystem;

    private float[] spectrum = new float[256];
    private float timePassed;

    // Update is called once per frame
    void Update()
    {
        timePassed = Timer.time; 
        if (timePassed >= 88f && timePassed <= 90f)
        {
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play(); 
            }
        }
        else
        {
            if (particleSystem.isPlaying)
            {
                particleSystem.Stop(); 
            }
        }

        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        float intensity = 0f;

        for (int i = 0; i < spectrum.Length; i++) 
        {
            intensity += spectrum[i];
        }    
        lightSource.intensity = Mathf.Lerp(0.1f, 3f, intensity * 100);

        float highFreq = spectrum[spectrum.Length - 1];
        lightSource.color = Color.Lerp(Color.red, Color.blue, highFreq);

        var main = particleSystem.main;
        var emission = particleSystem.emission;

        emission.rateOverTime = Mathf.Lerp(0, 10, intensity * 20f);
        main.startSize = Mathf.Lerp(0.1f, 5f, intensity * 10);
        main.startSpeed = Mathf.Lerp(1f, 10f, intensity * 5);
    }
}
