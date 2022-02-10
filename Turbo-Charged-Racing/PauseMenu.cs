using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool pausePressed;
    private bool gamePaused = false;
    public GameObject pauseMenu;
    public GameObject pauseStartButton;

    public void OnPauseGame(InputAction.CallbackContext context)
    {
        pausePressed = context.ReadValueAsButton();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseStartButton);

        PauseGame();
    }


    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReturnToMenu()
    {
        ResumeGame();
        SceneManager.LoadScene(0);
    }
}

