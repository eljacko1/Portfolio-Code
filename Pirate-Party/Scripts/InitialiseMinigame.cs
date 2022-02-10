using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialiseMinigame : MonoBehaviour
{
    [SerializeField]
    private SceneReference[] minigameScenesA;

    [SerializeField]
    private SceneReference[] minigameScenesB;

    [SerializeField]
    private SceneReference[] minigameScenesC;
    private int sceneIndex;
    private PlayerStats playerStats;
    public int currentArea;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        
    }

    public void StartMinigame()
    {
        currentArea = playerStats.currentRegion;
        if (currentArea == 0)
        {
            sceneIndex = Random.Range(0, minigameScenesA.Length);

            SceneManager.LoadScene(minigameScenesA[sceneIndex]);
        }

        else if(currentArea == 1)
        {
            sceneIndex = Random.Range(0, minigameScenesB.Length);

            SceneManager.LoadScene(minigameScenesB[sceneIndex]);
        }

        else if(currentArea == 2)
        {
            sceneIndex = Random.Range(0, minigameScenesC.Length);

            SceneManager.LoadScene(minigameScenesC[sceneIndex]);
        }

    }
}
