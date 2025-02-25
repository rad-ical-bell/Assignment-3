using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAnimate : MonoBehaviour
{
    public ParticleSystem mysticalParticles;
    private float timePassed = 0f;
    public float startTime = 38f;
    public float endTime = 45f;

    private ParticleSystem.EmissionModule emissionModule;  // Reference to the emission module of the particle system

    // Start is called before the first frame update
    void Start()
    {
        mysticalParticles.Stop();
        emissionModule = mysticalParticles.emission;  // Accessing the emission module to modify properties

        // Set the emission rate over time to a curve that starts at 0 and ramps up
        ParticleSystem.MinMaxCurve rateOverTime = new ParticleSystem.MinMaxCurve(0f, new AnimationCurve(
            new Keyframe(0f, 0f),
            new Keyframe(1f, 10f)  // Adjust the curve as needed
        ));
        emissionModule.rateOverTime = rateOverTime;

        // Add a burst of particles at random times within the start and end time
        for (int i = 0; i < 10; i++)  // Adjust the number of bursts as needed
        {
            float randomTime = Random.Range(startTime, endTime);
            emissionModule.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(randomTime, (short)Random.Range(1, 5)) });
        }
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed >= startTime && timePassed <= endTime)
        {
            if (!mysticalParticles.isPlaying)
            {
                mysticalParticles.Play();
            }
        }
        else
        {
            if (mysticalParticles.isPlaying)
            {
                mysticalParticles.Stop();
            }
        }
    }
}