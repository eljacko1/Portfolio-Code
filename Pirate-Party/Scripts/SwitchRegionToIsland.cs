using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRegionToIsland : MonoBehaviour
{
    private PlayerStats playerStats;


    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();

        if (playerStats.currentRegion == 2) { Destroy(gameObject); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1" || other.tag == "Player2")
        {
            playerStats.currentRegion = 2;

            Destroy(gameObject);
        }
    }
}
