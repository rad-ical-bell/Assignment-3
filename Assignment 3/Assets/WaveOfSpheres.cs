using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveOfSpheres : MonoBehaviour
{
    public int numberOfSpheres = 20;
    public float spacing = 0.5f;
    public float waveAmplitude = 2.0f;
    public float waveFrequency = 4.0f;
    public float offset = 0.0f;
    public float timer;
    public RotateObject hat;
    private List<Transform> objects = new List<Transform>();

    void CreateWave()
    {

        if (objects.Count == 0)
        {
            for (int i = 0; i < numberOfSpheres; i++)
            {
                GameObject obj;

                if (i % 2 == 0)
                {
                    obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                }
                else
                {
                    obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                }

                float x = i * spacing;
                float y = Mathf.Sin((x + offset) * waveFrequency) * waveAmplitude;

                obj.transform.position = new Vector3(x, y, 0);
                obj.transform.parent = this.transform;

                Renderer objRenderer = obj.GetComponent<Renderer>();

                float hue = Random.value; 
                Color saturatedColor = Color.HSVToRGB(hue, 1f, 1f); 
                objRenderer.material.color = saturatedColor;

                objects.Add(obj.transform);
            }
        }
    }

    void Update()
    {

        offset += Time.deltaTime;
        timer += Time.deltaTime;

        if (timer > 46 && objects.Count == 0)
        {
            CreateWave();
            timer = 0f; 
        }

        UpdateWavePositions();
    }

    void UpdateWavePositions()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            Transform obj = objects[i];
            float x = i * spacing;
            float y = Mathf.Sin((x + offset) * waveFrequency) * waveAmplitude;
            obj.position = new Vector3(x, y, 0);
        }
    }
}
