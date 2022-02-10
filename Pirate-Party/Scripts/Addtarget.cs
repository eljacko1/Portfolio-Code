using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Addtarget : MonoBehaviour
{
    public CinemachineTargetGroup targetbrain;

    GameObject player1;
    GameObject player2;

    //Lazy way to trick the target brain to not constantly add players
    int brainCheese;

    private void Start()
    {
        brainCheese = 0;
    }

    private void LateUpdate()
    {
        
        if (brainCheese == 0)
        {
            player1 = GameObject.FindWithTag("Player1");
            player2 = GameObject.FindWithTag("Player2");
            targetbrain.AddMember(player1.transform, 1f, 2f);
            targetbrain.AddMember(player2.transform, 1f, 2f);
            brainCheese = 1;
        }




    }
}
