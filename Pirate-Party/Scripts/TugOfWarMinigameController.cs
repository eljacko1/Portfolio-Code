using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TugOfWarMinigameController : MonoBehaviour
{
    public PlayerController[] playerControllers;
    private int player1Mash;
    private int player2Mash;
    public GameObject player1;
    public GameObject player2;
    [SerializeField]
    private GameObject[] spawnPoints;
    public PrepScreenManager prepScreenManager;
    [SerializeField]
    private BoxCollider triggerBox;
    [SerializeField]
    private Rigidbody ropeRB;

    [SerializeField]
    private GameObject timer;
    [SerializeField]
    private GameObject CountdownUI;

    private float player1Move = 1f;
    private float player2Move = 1f;

    public PlayerStats playerStats;
    private int winner;
    private bool countdownDone;

    //End/Start of round fade ins
    public GameObject IntroOutroPanel;
    Animator PanelAnimator;

    public AudioClip victory;
    public AudioSource Source;
    private void Start()
    {
        playerStats.LoadHighStakes();
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        player1.transform.position = spawnPoints[0].transform.position;
        player2.transform.position = spawnPoints[1].transform.position;

        player1.GetComponentInChildren<HingeJoint>().connectedBody = ropeRB;
        player2.GetComponentInChildren<HingeJoint>().connectedBody = ropeRB;

        playerControllers = GameObject.FindObjectsOfType<PlayerController>();
        playerControllers[0].buttonMashingGame = false;
        playerControllers[1].buttonMashingGame = false;

        //Setting Anim and State Integer
        PanelAnimator = IntroOutroPanel.GetComponent<Animator>();
        PanelAnimator.SetInteger("State", 0);
    
    }

    private IEnumerator Countdown()
    {
        countdownDone = true;

        if (playerStats.highStakes)
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

        timer.SetActive(true);
        timer.GetComponentInChildren<Timer>().timerIsRunning = true;
        timer.GetComponentInChildren<Timer>().timeRemaining = 60f;

        player1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;

        player2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;

        triggerBox.enabled = true;

        playerControllers[1].buttonMashingGame = true;
        playerControllers[0].buttonMashingGame = true;
        player1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        player2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

    }

    private void Update()
    {

        if(prepScreenManager.p1Ready && prepScreenManager.p2Ready && prepScreenManager.readyDone && !countdownDone)
        {
            StartCoroutine(Countdown());
        }


        if (playerControllers[1].pressed && prepScreenManager.p1Ready && prepScreenManager.p2Ready && prepScreenManager.readyDone)
        {
            player1Mash = playerControllers[1].mashCounter;

            if ((player1Mash % 5) == 0 && player1Mash != 0)
            {
                player1Move = player1Move + 1f;
            }

            float player1x = player1.transform.position.x - player1Move;

            player1.transform.position = Vector3.Lerp(player1.transform.position, new Vector3(player1x, player1.transform.position.y, player1.transform.position.z), Time.deltaTime);
        }

        if (playerControllers[0].pressed && prepScreenManager.p1Ready && prepScreenManager.p2Ready && prepScreenManager.readyDone)
        {
            player2Mash = playerControllers[0].mashCounter;

            if ((player2Mash % 5) == 0 && player2Mash != 0)
            {
                player2Move = player2Move + 1f;
            }

            float player2x = player2.transform.position.x + player2Move;

            player2.transform.position = Vector3.Lerp(player2.transform.position, new Vector3(player2x, player2.transform.position.y, player2.transform.position.z),  Time.deltaTime);
        }
    }

    private void RemoveRope()
    {
        GameObject[] ropeComponents = GameObject.FindGameObjectsWithTag("Rope");
        foreach(GameObject component in ropeComponents)
        {
            Destroy(component);
        }
    }


    public void WinnerPlayerTwo()
    {
        winner = 2;
        RemoveRope();
        playerControllers[0].buttonMashingGame = false;
        playerControllers[1].buttonMashingGame = false;
        Source.clip = victory;
        Source.Play();
        StartCoroutine(FinishMinigame());
    }
    public void WinnerPlayerOne()
    {
        winner = 1;
        RemoveRope();
        playerControllers[0].buttonMashingGame = false;
        playerControllers[1].buttonMashingGame = false;
        Source.clip = victory;
        Source.Play();
        StartCoroutine(FinishMinigame());
    }



    private IEnumerator FinishMinigame()
    {
        player1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationZ;
        player2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationZ;

        timer.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        if (winner == 1)
        {
            CountdownUI.GetComponentInChildren<TextMeshProUGUI>().text = "Player 1 Wins!";
            playerStats.p1Move = 8;

            if(!playerStats.highStakes)
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

            if(!playerStats.highStakes)
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
        yield return new WaitForSeconds(1.0f);


        playerStats.SavePlayerStats();
        SceneManager.LoadScene(1);

    }

    public void EndMinigame()
    {
        RemoveRope();
        winner = -1;
        StartCoroutine(FinishMinigame());
    }



}
