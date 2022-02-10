using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TightSqueezeMinigameController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnPoints;
    [SerializeField]
    private GameObject CountdownUI;
    public SpawnSystem spawnSystem;
    public ScenerySpawnSystem scenerySpawnSystem;
    public RockSpawnSystem rockSpawnSystem;

    [SerializeField]
    private PlayerStats playerStats;
    public PlayerController[] playerControllers;
    public GameObject player1;
    public GameObject player2;

    [SerializeField]
    SceneReference mainGame;

    int winner = 0;
    public GameObject IntroOutroPanel;
    Animator PanelAnimator;

    public AudioSource source;
    public AudioClip Victory;

    // Start is called before the first frame update
    void Start()
    {
        playerStats.LoadHighStakes();
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        playerControllers = FindObjectsOfType<PlayerController>();

        player1.transform.position = spawnPoints[0].transform.position;
        player2.transform.position = spawnPoints[1].transform.position;

        StartCoroutine(Countdown());
        PanelAnimator = IntroOutroPanel.GetComponent<Animator>();
        PanelAnimator.SetInteger("State", 0);
    }

    private IEnumerator Countdown()
    {
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

        spawnSystem.enabled = true;
        scenerySpawnSystem.enabled = true;
        rockSpawnSystem.enabled = true;
        spawnSystem.timer.isRunning = true;
        scenerySpawnSystem.timer.isRunning = true;
        rockSpawnSystem.timer.isRunning = true;
        player1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        player2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        foreach (PlayerController controller in playerControllers)
        {
            controller.enabled = true;
        }
    }




    public void RemovePlayerOne()
    {
        spawnSystem.timer.isRunning = false;
        scenerySpawnSystem.timer.isRunning = false;
        rockSpawnSystem.timer.isRunning = false;
        player1.SetActive(false);
        winner = 2;
        RemoveObjects();
        StartCoroutine(FinishMinigame());
    }
    public void RemovePlayerTwo()
    {
        spawnSystem.timer.isRunning = false;
        scenerySpawnSystem.timer.isRunning = false;
        rockSpawnSystem.timer.isRunning = false;
        player2.SetActive(false);
        winner = 1;
        RemoveObjects();
        StartCoroutine(FinishMinigame());
    }

    public void EndMinigame()
    {
        winner = -1;
        RemoveObjects();
        StartCoroutine(FinishMinigame());
    }

    private IEnumerator FinishMinigame()
    {
        player1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        player2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(0.5f);

        if (winner == 1)
        {
            CountdownUI.GetComponentInChildren<TextMeshProUGUI>().text = "Player 1 Wins!";
            playerStats.p1Move = 8;

            source.clip = Victory;
            source.Play();

            if (!playerStats.highStakes)
            {
                playerStats.p2Move = 4;
            }
            else
            {
                playerStats.p2Move = 0;
            }

            player1.SetActive(true);
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

            source.clip = Victory;
            source.Play();

            playerStats.p2Move = 8;

            player1.SetActive(true);
            player1.transform.position = spawnPoints[0].transform.position;
            player2.SetActive(true);
            player2.transform.position = spawnPoints[1].transform.position;

            player1.GetComponentInChildren<Animator>().SetBool("Lose", true);
            player2.GetComponentInChildren<Animator>().SetBool("Win", true);
        }

        else
        {
            CountdownUI.GetComponentInChildren<TextMeshProUGUI>().text = "It's a Tie!";
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
        yield return new WaitForSeconds(1.0f);

        playerStats.SavePlayerStats();
        SceneManager.LoadScene(mainGame);

    }

    void RemoveObjects()
    {
        GameObject[] wallsToRemove = GameObject.FindGameObjectsWithTag("Wall");
        GameObject[] sceneryToRemove = GameObject.FindGameObjectsWithTag("Scenery");
        GameObject[] rocksToRemove = GameObject.FindGameObjectsWithTag("Rocks");
        spawnSystem.enabled = false;
        scenerySpawnSystem.enabled = false;
        rockSpawnSystem.enabled = false;
        foreach (GameObject wall in wallsToRemove)
        {
            Destroy(wall);
        }

        foreach (GameObject scenery in sceneryToRemove)
        {
            Destroy(scenery);
        }

        foreach (GameObject rocks in rocksToRemove)
        {
            Destroy(rocks);
        }
    }
}
