using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    [SerializeField]
    private TugOfWarMinigameController tugOfWarMinigameController;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player1")
        {
            tugOfWarMinigameController.WinnerPlayerTwo();
        }

        if(other.gameObject.tag == "Player2")
        {
            tugOfWarMinigameController.WinnerPlayerOne();
        }
    }
}
