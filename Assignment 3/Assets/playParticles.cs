using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playParticles : MonoBehaviour
{
    public float timer;
    public ParticleSystem particleSystem;
    private bool hasPlayed = false;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 46 && !hasPlayed)
        {
            particleSystem.Play(); 
            hasPlayed = true; 
        }
    }
}
