using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30;
    public bool timerIsRunning = false;
    public Text timeText;

    [SerializeField]
    private CannonMinigameController cannonMinigameController;
    [SerializeField]
    private TugOfWarMinigameController towMinigameController;
    [SerializeField]
    private RaceMinigameController raceMinigameController;

    private void Start()
    {

    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                if(cannonMinigameController != null)
                {
                    cannonMinigameController.EndMinigame();
                }

                else if(towMinigameController != null)
                {
                    towMinigameController.EndMinigame();
                }

                else if(raceMinigameController != null)
                {
                    raceMinigameController.EndMinigame();
                }
                

            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
