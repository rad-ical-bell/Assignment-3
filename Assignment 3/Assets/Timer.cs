using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float maxTime = 223.0f;

    // Update is called once per frame
    void Update()
    {
        if (maxTime > 0)
        {
            maxTime -= Time.deltaTime;
            Debug.Log(maxTime);
         
        }
        else
        {
            stopAll();
        }
        
    }

    void stopAll()
    {
        return;
    }
}
