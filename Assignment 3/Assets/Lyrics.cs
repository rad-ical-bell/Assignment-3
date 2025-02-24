using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lyrics : MonoBehaviour
{
    public TextMeshProUGUI lyricsText; 
    public float startTime = 38f; 
    public float endTime = 45f; 
    public float moveSpeed = 5f;
    public Vector3 startPosition = new Vector3(6, -194, 0); 
    public Vector3 endPosition = new Vector3(6, 99, 0);

    private float timer = 0f;
    private bool isShowing = false;

    // Start is called before the first frame update
    void Start()
    {
        lyricsText.transform.position = startPosition;
        lyricsText.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Timer.time;

        if (timer >= startTime && timer <= endTime)
        {
            if (!isShowing)
            {
                lyricsText.gameObject.SetActive(true); 
                lyricsText.color = Color.white; 
                isShowing = true;
            }

            lyricsText.transform.position = Vector3.Lerp(lyricsText.transform.position, endPosition, Time.deltaTime * moveSpeed);
        }
        else
        {
            if (isShowing)
            {
                lyricsText.gameObject.SetActive(false); 
                isShowing = false;
            }
        }
    }
}
