using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAnimate : MonoBehaviour
{
    public ParticleSystem mysticalParticles;  
    private float timePassed = 0f;
    public float startTime = 38f;  
    public float endTime = 45f;   
    
    // Start is called before the first frame update
    void Start()
    {
        mysticalParticles.Stop();
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