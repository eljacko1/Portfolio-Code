using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject trackSelectFirstButton, additionalMenuCloseButton, settingsFirstOption;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("RawTime"))
        {
            PlayerPrefs.SetFloat("RawTime", 1000000000);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OpenTrackSelect()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(trackSelectFirstButton);
    }

    public void OpenSettings()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsFirstOption);
    }
    public void CloseAdditionalMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(additionalMenuCloseButton);
    }

    public void LoadTrack1()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadTrack2()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
