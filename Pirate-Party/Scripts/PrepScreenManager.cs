using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PrepScreenManager : MonoBehaviour
{
    public PrepScreenScriptableObject prepScreen;
    private PlayerController[] playerControllers;
    public GameObject prepScreenObject;
    public GameObject[] uiElements;

    public GameObject loadingScreen;
    public CannonMinigameController cannonMinigameController;
    public TightSqueezeMinigameController tightSqueezeMinigameController;
    public RaceMinigameController raceMinigameController;
    public int delay;

    public bool p1Ready;
    public bool p2Ready;
    public bool readyDone;

    //Animator
    Animator PrepAnimator;


    // Start is called before the first frame update
    void Start()
    {
        uiElements = GameObject.FindGameObjectsWithTag("PrepScreen");
        playerControllers = FindObjectsOfType<PlayerController>();
        //Setting Anim and State Integer
        PrepAnimator = prepScreenObject.GetComponent<Animator>();
        PrepAnimator.SetInteger("State", 0);
        SetText();
    }

    void SetText()
    {
        for (int i = 0; i < uiElements.Length; i++)
        {
            if (uiElements[i].name == "MinigameTitle")
            {
                uiElements[i].GetComponent<TextMeshProUGUI>().text = prepScreen.minigameName;
            }           
            else if (uiElements[i].name == "MinigameRules")
            {
                uiElements[i].GetComponent<TextMeshProUGUI>().text = prepScreen.minigameInstructions;
            }
            else if(uiElements[i].name == "Player1Ready")
            {
                uiElements[i].SetActive(false);
                
            }  
            else if(uiElements[i].name == "Player2Ready")
            {
                uiElements[i].SetActive(false);
            }
            else if (uiElements[i].name == "ControlsP1Text")
            {

                uiElements[i].GetComponent<TextMeshProUGUI>().text = prepScreen.controlsP1;
                
            }
            else if (uiElements[i].name == "ControlsP2Text")
            {
                uiElements[i].GetComponent<TextMeshProUGUI>().text = prepScreen.controlsP2;
            }


        }
    }

    private void Update()
    {
        if (playerControllers[1].player1ReadyUp)
        {
            for (int i = 0; i < uiElements.Length; i++)
            {
                if(uiElements[i].name == "Player1Ready")
                {
                    uiElements[i].SetActive(true);
                }
            }
            p1Ready = true;
        }

        if (playerControllers[0].player2ReadyUp)
        {
            for (int i = 0; i < uiElements.Length; i++)
            {
                if (uiElements[i].name == "Player2Ready")
                {
                    uiElements[i].SetActive(true);
                }
            }
            p2Ready = true;
        }

        if (p1Ready && p2Ready && !readyDone)
        {
            StartCoroutine(Delay());
            //prepScreenObject.SetActive(false);



        }
    }

    private IEnumerator Delay()
    {
        PrepAnimator.SetInteger("State", 1);
        //loadingScreen.SetActive(true);
        yield return new WaitForSeconds(delay);
       // loadingScreen.SetActive(false);
        readyDone = true;
        if(cannonMinigameController != null)
        {
            cannonMinigameController.enabled = true;
        }
        if(tightSqueezeMinigameController != null)
        {
            tightSqueezeMinigameController.enabled = true;
        }
        if (raceMinigameController != null)
        {
            raceMinigameController.enabled = true;
        }
    }     
}
