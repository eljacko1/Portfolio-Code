using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class CannonMinigameController : MonoBehaviour
{ 
    [SerializeField]
    private GameObject CountdownUI;
    [SerializeField]
    private GameObject timer;
    [SerializeField]
    private GameObject cannons;
    [SerializeField]
    private PlayerStats playerStats;
    public PlayerController[] playerControllers;
    public GameObject player1;
    public GameObject player2;
    [SerializeField]
    private GameObject[] spawnPoints;
    public GameObject[] missileArray;
    //Player Rigidbodies to disable movement before GO.
    Rigidbody P1rb;
    Rigidbody P2rb;

    int winner = 0;
    public AudioClip Firework;
    public AudioSource Source;

        //End/Start of round fade ins
    public GameObject IntroOutroPanel;
    Animator PanelAnimator;


    private void Start()
    {
        playerControllers = FindObjectsOfType<PlayerController>();
        foreach (PlayerController controller in playerControllers)
        {
            controller.enabled = false;
        }

        playerStats.LoadHighStakes();
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        player1.transform.position = spawnPoints[0].transform.position;
        player2.transform.position = spawnPoints[1].transform.position;

        StartCoroutine(Countdown());
        //Setting Anim and State Integer
        PanelAnimator = IntroOutroPanel.GetComponent<Animator>();
        PanelAnimator.SetInteger("State", 0);

        Source.GetComponent<AudioSource>();
    }

    private IEnumerator Countdown()
    {
        if(playerStats.highStakes)
        {
            CountdownUI.GetComponentInChildren<TextMeshProUGUI>().text = "HIGH STAKES!";
            CountdownUI.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            CountdownUI.SetActive(false);
        }


        CountdownUI.GetComponentInChildren<TextMeshProUGUI>().text = "Get Ready!";
        CountdownUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        CountdownUI.SetActive(false);
        CountdownUI.GetComponentInChildren<TextMeshProUGUI>().text = "START!";
        CountdownUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        CountdownUI.SetActive(false);



        cannons.SetActive(true);
        foreach (PlayerController controller in playerControllers)
        {
            controller.enabled = true;
        }
        timer.SetActive(true);
        timer.GetComponentInChildren<Timer>().timerIsRunning = true;
        timer.GetComponentInChildren<Timer>().timeRemaining = 30f;
        player1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        player2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void FixedUpdate()
    {
        missileArray = GameObject.FindGameObjectsWithTag("Missile");
    }

    public void RemovePlayerOne()
    {
        player1.SetActive(false);
        winner = 2;


        RemoveMissiles();

        StartCoroutine(FinishMinigame());
    }
    public void RemovePlayerTwo()
    {
        player2.SetActive(false);
        winner = 1;


        RemoveMissiles();

        StartCoroutine(FinishMinigame());
    }



    private IEnumerator FinishMinigame()
    {
        player1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        player2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        foreach (PlayerController controller in playerControllers)
        {
            controller.enabled = false;
        }
        cannons.SetActive(false);
        timer.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        if (winner == 1)
        {
            VictorySounds();
            CountdownUI.GetComponentInChildren<TextMeshProUGUI>().text = "Player 1 Wins!";
            playerStats.p1Move = 8;

            if (!playerStats.highStakes)
            {
                playerStats.p2Move = 4;
            }
            else
            {
                playerStats.p2Move = 0;
            }

            player1.transform.position = spawnPoints[0].transform.position;
            player2.SetActive(true);
            player2.transform.position = spawnPoints[1].transform.position;

            player1.GetComponentInChildren<Animator>().SetBool("Win", true);
            player2.GetComponentInChildren<Animator>().SetBool("Lose", true);
        }

        else if (winner == 2)
        {
            VictorySounds();
            CountdownUI.GetComponentInChildren<TextMeshProUGUI>().text = "Player 2 Wins!";
            if (!playerStats.highStakes)
            {
                playerStats.p1Move = 4;
            }
            else
            {
                playerStats.p1Move = 0;
            }

            playerStats.p2Move = 8;

            player1.transform.position = spawnPoints[0].transform.position;
            player1.SetActive(true);
            player2.transform.position = spawnPoints[1].transform.position;

            player1.GetComponentInChildren<Animator>().SetBool("Lose", true);
            player2.GetComponentInChildren<Animator>().SetBool("Win", true);
        }

        else
        {
            CountdownUI.GetComponentInChildren<TextMeshProUGUI>().text = "Time is up!";
            if (!playerStats.highStakes)
            {
                playerStats.p1Move = 5;
                playerStats.p2Move = 5;
            }
            else
            {
                playerStats.p1Move = 0;
                playerStats.p2Move = 0;
            }


            player1.transform.position = spawnPoints[0].transform.position;
            player2.transform.position = spawnPoints[1].transform.position;

            player1.GetComponentInChildren<Animator>().SetBool("Lose", true);
            player2.GetComponentInChildren<Animator>().SetBool("Lose", true);
        }

        CountdownUI.SetActive(true);
        yield return new WaitForSeconds(4f);
        CountdownUI.SetActive(false);
        PanelAnimator.SetInteger("State", 1);
        yield return new WaitForSeconds(1f);

        playerStats.SavePlayerStats();
        SceneManager.LoadScene(1);

    }

    public void EndMinigame()
    {
        winner = -1;
        RemoveMissiles();
        StartCoroutine(FinishMinigame());
    }

    private void RemoveMissiles()
    {
        for (int i = 0; i < missileArray.Length; i++)
        {
            missileArray[i].SetActive(false);
        }
    }
    public void VictorySounds()
    {
        Source.clip = Firework;
        Source.Play();
    }
}
