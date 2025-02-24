using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beams : MonoBehaviour
{
    public AudioSource audioSource;
    public LineRenderer lineRenderer; 
    public int numOfRibbons = 100;    
    public float ribbonLength = 10f; 
    public float maxHeight = 3f;     
    public float movementSpeed = 1f; 
    private GameObject[] ribbons;   
    private float[] audioData;       
    private float timePassed;
    private float startTime = 15f;   
    private float endTime = 20f;     

    // Start is called before the first frame update
    void Start()
    {
        ribbons = new GameObject[numOfRibbons];
        audioData = new float[128]; 
    }

    // Update is called once per frame
    void Update()
    {
        timePassed = Timer.time;  

        if (timePassed >= startTime && timePassed <= endTime)
        {
            if (ribbons[0] == null)
            {
                SpawnRibbons();
            }
            ReactToAudio();
        }
        else
        {
            if (timePassed > endTime)
            {
                DestroyRibbons();
            }
        }
    }

    void SpawnRibbons()
    {
        for (int i = 0; i < numOfRibbons; i++)
        {
            ribbons[i] = new GameObject("Ribbon" + i);
            LineRenderer line = ribbons[i].AddComponent<LineRenderer>();
            line.positionCount = 2; 
            line.SetPosition(0, new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f))); 
            line.SetPosition(1, line.GetPosition(0)); 

            line.startWidth = 0.1f;
            line.endWidth = 0.1f;
            line.material = new Material(Shader.Find("Sprites/Default"));
            line.startColor = Color.cyan;
            line.endColor = Color.magenta;
        }
    }

    void ReactToAudio()
    {
        audioSource.GetOutputData(audioData, 0);  

        for (int i = 0; i < numOfRibbons; i++)
        {
            if (ribbons[i] != null)
            {
                LineRenderer lineRenderer = ribbons[i].GetComponent<LineRenderer>();
                float amplitude = audioData[i + 64]; 

                Vector3 newPosition = new Vector3(lineRenderer.GetPosition(1).x, Mathf.Sin(Time.time * movementSpeed + i) * amplitude * maxHeight, lineRenderer.GetPosition(1).z);
                lineRenderer.SetPosition(1, newPosition);

                Color ribbonColor = new Color(amplitude, 0f, 1f - amplitude);
                lineRenderer.startColor = ribbonColor;
                lineRenderer.endColor = ribbonColor;
            }
        }
    }

    void DestroyRibbons()
    {
        for (int i = 0; i < numOfRibbons; i++)
        {
            if (ribbons[i] != null)
            {
                Destroy(ribbons[i]);
            }
        }
    }
}
