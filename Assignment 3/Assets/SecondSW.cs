using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSW : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject cube;
    public int numOfCubes = 128;
    public float maxHeight = 10f;
    public float spacing = 0.2f;

    private GameObject[] cubes;
    private float[] audioData;
    private MaterialPropertyBlock propertyBlock;
    private bool cubesDestroyed = false;

    void Start()
    {
        cubes = new GameObject[numOfCubes];
        audioData = new float[numOfCubes];
        propertyBlock = new MaterialPropertyBlock();
    }

    void Update()
    {
        float timePassed = Timer.time;

        if (timePassed >= 171f && timePassed <= 202f)
        {
            if (timePassed >= 171f && timePassed < 202f && cubes == null)
            {
                CreateCubes();
            }

            if (cubes != null)
            {
                audioSource.GetOutputData(audioData, 0);

                for (int i = 0; i < numOfCubes; i++)
                {
                    float amplitude = audioData[i];
                    cubes[i].transform.localScale = new Vector3(cubes[i].transform.localScale.x, amplitude * maxHeight, cubes[i].transform.localScale.z);
                }

                VisualizeBass();
                VisualizeMidrange();
                VisualizeTreble();
            }
        }
        else
        {
            if (cubes != null)
            {
                DestroyCubes();
            }
        }

        // Glitch effect (kept as is for any time during the range 171-202 seconds if needed)
        if (timePassed < 8f)
        {
            Glitch(timePassed);
        }

        if (timePassed >= 8f && !cubesDestroyed)
        {
            DestroyCubes();
        }
    }

    void Glitch(float timePassed)
    {
        for (int i = 0; i < numOfCubes; i++)
        {
            float offsetX = Random.Range(-0.1f, 0.1f);
            float offsetY = Random.Range(-0.1f, 0.1f);
            float offsetZ = Random.Range(-0.1f, 0.1f);

            cubes[i].transform.position += new Vector3(offsetX, offsetY, offsetZ);

            float randomScale = Random.Range(0.5f, 1.5f);
            cubes[i].transform.localScale = new Vector3(cubes[i].transform.localScale.x, randomScale * maxHeight, cubes[i].transform.localScale.z);

            Renderer cubeRenderer = cubes[i].GetComponent<Renderer>();
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            cubeRenderer.GetPropertyBlock(propertyBlock);
            propertyBlock.SetColor("_Color", randomColor);
            cubeRenderer.SetPropertyBlock(propertyBlock);
        }
    }

    void CreateCubes()
    {
        cubes = new GameObject[numOfCubes];
        for (int i = 0; i < numOfCubes; i++)
        {
            cubes[i] = Instantiate(cube, new Vector3(i * spacing - 2f, 0, 0), Quaternion.identity);
            cubes[i].transform.SetParent(transform);
        }

        cubesDestroyed = false;
    }

    void DestroyCubes()
    {
        if (cubes != null)
        {
            for (int i = 0; i < cubes.Length; i++)
            {
                Destroy(cubes[i]);
            }

            cubes = null;
            cubesDestroyed = true;
        }
    }

    void VisualizeBass()
    {
        float bassAmplitude = 0f;

        for (int i = 0; i < numOfCubes / 4; i++)
        {
            bassAmplitude += audioData[i];
        }

        Color bassColor = new Color(bassAmplitude, 0f, 0f);

        for (int i = 0; i < numOfCubes / 4; i++)
        {
            Renderer cubeRenderer = cubes[i].GetComponent<Renderer>();
            cubeRenderer.GetPropertyBlock(propertyBlock);
            propertyBlock.SetColor("_Color", bassColor);
            cubeRenderer.SetPropertyBlock(propertyBlock);
        }
    }

    void VisualizeMidrange()
    {
        float midAmplitude = 0f;

        for (int i = numOfCubes / 4; i < numOfCubes / 2; i++)
        {
            midAmplitude += audioData[i];
        }

        Color midColor = new Color(0f, midAmplitude, 0f);

        for (int i = numOfCubes / 4; i < numOfCubes / 2; i++)
        {
            Renderer cubeRenderer = cubes[i].GetComponent<Renderer>();
            cubeRenderer.GetPropertyBlock(propertyBlock);
            propertyBlock.SetColor("_Color", midColor);
            cubeRenderer.SetPropertyBlock(propertyBlock);
        }
    }

    void VisualizeTreble()
    {
        float trebleAmplitude = 0f;

        for (int i = numOfCubes / 2; i < numOfCubes; i++)
        {
            trebleAmplitude += audioData[i];
        }

        Color trebleColor = new Color(0f, 0f, trebleAmplitude);

        for (int i = numOfCubes / 2; i < numOfCubes; i++)
        {
            Renderer cubeRenderer = cubes[i].GetComponent<Renderer>();
            cubeRenderer.GetPropertyBlock(propertyBlock);
            propertyBlock.SetColor("_Color", trebleColor);
            cubeRenderer.SetPropertyBlock(propertyBlock);
        }
    }
}