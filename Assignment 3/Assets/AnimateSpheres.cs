using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSpheres : MonoBehaviour
{
    public GameObject circlePrefab; 
    public int numCircles = 10; 
    public float spawnDistance = 30f; 
    public float moveSpeed = 5f; 
    public float maxScale = 3f; 
    private GameObject[] circles; 
    private Vector3[] startPositions; 
    private float timePassed;

    void Start()
    {
        circles = new GameObject[numCircles];
        startPositions = new Vector3[numCircles];

        for (int i = 0; i < numCircles; i++)
        {
            float angle = Random.Range(0f, Mathf.PI * 2f);
            float height = Random.Range(-Mathf.PI / 4f, Mathf.PI / 4f);
            float distance = Random.Range(spawnDistance, spawnDistance + 10f);
            Vector3 spawnPosition = new Vector3(
                Mathf.Cos(angle) * Mathf.Cos(height) * distance,
                Mathf.Sin(height) * distance,
                Mathf.Sin(angle) * Mathf.Cos(height) * distance
            );

            startPositions[i] = spawnPosition;
            circles[i] = Instantiate(circlePrefab, spawnPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        timePassed = Timer.time; 

        if (timePassed >= 10f && timePassed <= 20f)
        {
            for (int i = 0; i < numCircles; i++)
            {
                Vector3 directionToCamera = (Camera.main.transform.position - circles[i].transform.position).normalized;
                circles[i].transform.position += directionToCamera * moveSpeed * Time.deltaTime;

                float distanceToCamera = Vector3.Distance(circles[i].transform.position, Camera.main.transform.position);
                float scaleFactor = Mathf.Lerp(1f, maxScale, 1f - Mathf.Clamp01(distanceToCamera / spawnDistance));
                circles[i].transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
            }
        }
        else
        {
            for (int i = 0; i < numCircles; i++)
            {
                circles[i].SetActive(false);
            }
        }
    }
}
