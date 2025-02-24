using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float time = 0f;

    // Update is called once per frame
    void Update()
    {
        if (time < 223)
        {
            time += Time.deltaTime;
        }
        else
        {
            stopAll();
        }
        
    }

    void stopAll()
    {
        Debug.Log("all done");
    }
}
