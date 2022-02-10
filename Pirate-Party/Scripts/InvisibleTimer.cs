using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvisibleTimer : MonoBehaviour
{
    public float time = 0;
    public bool isRunning = false;

    void Update()
    {
        if (isRunning)
        {
            time += Time.deltaTime;
            DisplayTime(time);
        }

        if(time > 68)
        {
            isRunning = false;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
