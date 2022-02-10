using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    private GameObject minigameControllerGO;
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
           minigameController.RemovePlayerTwo();
           Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player2Body")
        {
            minigameController.RemovePlayerOne();
            Destroy(gameObject);
        }
      

    }
}
