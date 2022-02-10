using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRegionToPort : MonoBehaviour
{
    private PlayerStats playerStats;


    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();

        if(playerStats.currentRegion == 0) { Destroy(gameObject); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1" || other.tag == "Player2")
        {
            playerStats.currentRegion = 0;

            Destroy(gameObject);
        }
    }
}
