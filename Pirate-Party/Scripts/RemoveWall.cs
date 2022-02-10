using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWall : MonoBehaviour
{
    private TightSqueezeMinigameController minigameController;
    bool penultimateWall;
    public InvisibleTimer timer;

    private void Start()
    {
        minigameController = GameObject.FindObjectOfType<TightSqueezeMinigameController>();
    }

    private void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.tag == "Player1")
        {
            minigameController.RemovePlayerOne();
        }

        else if(other.gameObject.tag == "Player2")
        {
            minigameController.RemovePlayerTwo();
        }

        else if(other.gameObject.tag == "Wall")
        {
            Destroy(other.gameObject);
        }
    
        else if(other.gameObject.tag == "Rocks")
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Scenery")
        {
            
            Destroy(other.gameObject);
        }

    }

    void Update()
    {
        if(timer.isRunning == false && minigameController.spawnSystem.walls.Count == 0)
        {
            minigameController.EndMinigame();
        }
    }
}
