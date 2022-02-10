using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class RaceFinish : MonoBehaviour
{
    public GameObject myCar;
    public GameObject finishCam;
    public GameObject viewModes;
    public GameObject levelMusic;
    public AudioSource finishMusic;
    public GameObject finishTrigger;
    public GameObject lapTimer;
    public GameObject winPanel;
    public GameObject losePanel;

    public GameObject winStartButton;
    public GameObject loseStartButton;

    private int position;

    private void OnTriggerEnter()
    {
        myCar.SetActive(false);
        CarController.m_Topspeed = 0.0f;
        myCar.GetComponent<CarController>().enabled = false;
        position = myCar.GetComponent<CarUserControl>().currentPosition;
        myCar.GetComponent<CarUserControl>().enabled = false;
        myCar.SetActive(true);
        finishCam.SetActive(true);
        levelMusic.SetActive(false);
        viewModes.SetActive(false);
        finishMusic.Play();
        lapTimer.SetActive(false);
        Gamepad.current.SetMotorSpeeds(0, 0);
        finishTrigger.SetActive(false);
        Invoke("ReturnToMenu", 5f);
    }

    private void ReturnToMenu()
    {


        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (position == 1)
            {
                winPanel.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(winStartButton);
            }
            else if (position == 2)
            {
                losePanel.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(loseStartButton);
            }
        }

        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ReturnToMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
      
}
