using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [HideInInspector]public bool isGamePaused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] InitialiseMinigame initialiseMinigame;
    [SerializeField] SceneReference mainMenu;
    [SerializeField] SceneReference loading;

    [SerializeField] CardSystem cardSystem;

    //Main Menu Assets & thier Animators
    [SerializeField] GameObject Title;
    Animator TitleAnimator;
    [SerializeField] GameObject MenuButtons;
    Animator ButtonAnimator;
    [SerializeField] GameObject Prompt;
    [SerializeField] GameObject IntroOutroPanel;
    Animator IntroAnimator;
    [SerializeField] GameObject Exit;
    Animator ExitAnimator;

    [SerializeField] GameObject Credits;
    Animator CreditsAnimator;

    //Settings & Controls use the same Panel
    [SerializeField] GameObject ControlsPanel;
    Animator ControlsAnimator;

    public AudioSource Sound;
    public AudioClip Selection;
    public AudioClip Hover;

    void Start()
    {
        Time.timeScale = 1f;
        //Setting Each Anim and State Integers
        if(Title != null)
        {
            TitleAnimator = Title.GetComponent<Animator>();
            TitleAnimator.SetInteger("State", 0);
        }

        if(MenuButtons != null)
        {
            ButtonAnimator = MenuButtons.GetComponent<Animator>();
            ButtonAnimator.SetInteger("State", 0);
        }

        if(IntroOutroPanel != null)
        {
            IntroAnimator = IntroOutroPanel.GetComponent<Animator>();
            IntroAnimator.SetInteger("State", 0);
        }

        if(ControlsPanel != null)
        {
            ControlsAnimator = ControlsPanel.GetComponent<Animator>();
            ControlsAnimator.SetInteger("State", 0);
        }
        if (Exit != null)
        {
            ExitAnimator = Exit.GetComponent<Animator>();
            ExitAnimator.SetInteger("State", 0);
        }
        if(Credits != null)
        {
            CreditsAnimator = Credits.GetComponent<Animator>();
            CreditsAnimator.SetInteger("State", 0);
            Credits.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && Title != null)
        {
            PressAnyButton();
        }
    }

    //Upon Pressing Any Button At The Beginning
    public void PressAnyButton()
    {
        if( TitleAnimator.GetInteger("State") == 0)
        {
            TitleAnimator.SetInteger("State", 1);
            ButtonAnimator.SetInteger("State", 1);
            Prompt.SetActive(false);
        }

    }

    //Quick fix to have the "IntroOutroPanel" have its anim play and then load scenes
    public void PlayButtonCheese()
    {
        if(Selection != null)
        {
            Sound.clip = Selection;
            Sound.Play();
        }

        IntroAnimator.SetInteger("State", 1);
        Invoke("LoadLoadingScene", 1f);
    }
    
    //Loads Loading scene
    public void LoadLoadingScene()
    {
        if (Selection != null)
        {
            Sound.clip = Selection;
            Sound.Play();
        }
        SceneManager.LoadScene(loading);
    }

    //Brings the Controls Panel Up, Moves the buttons out of view
    public void BringControlsUp()
    {
        if (Selection != null)
        {
            Sound.clip = Selection;
            Sound.Play();
        }
        ButtonAnimator.SetInteger("State", 2);
        ControlsAnimator.SetInteger("State", 1);
    }

    public void BringControlsDown()
    {
        if (Selection != null)
        {
            Sound.clip = Selection;
            Sound.Play();
        }
        ButtonAnimator.SetInteger("State", 1);
        ControlsAnimator.SetInteger("State", 0);
    }
    //bring the Exit menu up (to ensure the player didnt accidentally exit)
    public void ExitUp()
    {
        if (Selection != null)
        {
            Sound.clip = Selection;
            Sound.Play();
        }
        ExitAnimator.SetInteger("State", 1);
    }
    public void ExitDown()
    {
        if (Selection != null)
        {
            Sound.clip = Selection;
            Sound.Play();
        }
        ExitAnimator.SetInteger("State", 0);
    }

    public void ResumeGame()
    {
        if (cardSystem.currentCard != null && cardSystem != null)
        {
            cardSystem.currentCard.SetActive(true);
        }

        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isGamePaused = false;
        }
    }

    void PauseGame()
    {
        if(pauseMenu != null)
        {
            if (cardSystem.currentCard != null && cardSystem != null)
            {
                cardSystem.currentCard.SetActive(false);
            }

            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isGamePaused = true;
        }
    }

    public void PauseUnpause(InputAction.CallbackContext context)
    {
        if (isGamePaused)
        {
            ResumeGame();
        }
        else if (!isGamePaused)
        {
            PauseGame();
        }
    }

    public void StartGame()
    {
        if (Selection != null)
        {
            Sound.clip = Selection;
            Sound.Play();
        }
        initialiseMinigame.StartMinigame();
    }

    public void QuitGame()
    {
        if (Selection != null)
        {
            Sound.clip = Selection;
            Sound.Play();
        }
        Application.Quit();
        Debug.Log("Quit");
    }

    public void ReturnToMenu()
    {
        if (Selection != null)
        {
            Sound.clip = Selection;
            Sound.Play();
        }
        SceneManager.LoadScene(mainMenu);
    }
    public void OnMouseOver()
    {
        if (Hover != null)
        {
            Sound.clip = Hover;
            Sound.Play();
        }
    }

    public void CreditsUp()
    {
        Credits.SetActive(true);
        CreditsAnimator.SetInteger("State", 1);
    }

    public void CreditsDown()
    {
        Credits.SetActive(true);
        CreditsAnimator.SetInteger("State", 0);
    }

}
