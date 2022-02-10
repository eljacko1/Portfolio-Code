using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallen : MonoBehaviour
{
    private RaceMinigameController minigameController;
    void Start()
    {
        minigameController = FindObjectOfType<RaceMinigameController>();
    }


    void Update()
    {

    }

    
    private void OnTriggerEnter(Collider other)
    {
       
        // on collsion with Players
        if (other.gameObject.tag == "Player1Body")
        {
           minigameController.RemovePlayerOne();
           Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player2Body")
        {
            minigameController.RemovePlayerTwo();
            Destroy(gameObject);
        }
      

    }
}
