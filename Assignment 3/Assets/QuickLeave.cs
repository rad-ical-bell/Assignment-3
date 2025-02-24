using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickLeave : MonoBehaviour
{
    
   GameObject[] spheres;
   int numSphere = 10;
   float speed = 10f;
   Vector3[] posit;
    // Start is called before the first frame update
    void Start()
    {
        spheres = new GameObject[numSphere];
        posit = new Vector3[numSphere];

        for (int i = 0; i < numSphere; i++) 
        {
            spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        float timePassed = Timer.time;

        if (timePassed < 10f)
        {
              
        }
       
    }
}

