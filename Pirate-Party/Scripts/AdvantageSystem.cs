using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvantageSystem : MonoBehaviour
{
    [SerializeField]
    private Movement player1MovementScript;
    [SerializeField]
    private Movement player2MovementScript;

    public int winningPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player1MovementScript.routePosition - player2MovementScript.routePosition > 10)
        {
            winningPlayer = 1;
        }
        else if(player2MovementScript.routePosition - player1MovementScript.routePosition > 10)
        {
            winningPlayer = 2;
        }
        else
        {
            winningPlayer = 0;
        }
    }
}
