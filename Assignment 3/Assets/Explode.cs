using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public float timer;
    public ParticleSystem particleSystem;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 67)
        {
            particleSystem.Play(); 
        
        }
    }
}
