using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Movement[] players;
    public PlayerStats playerStats;
    public int currentPlayerTurn = 1;
    public bool cardEvent = false;
    public CardSystem cardSystem;
    public int movementMode = 0;

    public Animator player1Anim;
    public Animator player2Anim;

    [SerializeField] GameObject P1HUD;
    Animator P1HUDAnim;
    [SerializeField] GameObject P2HUD;
    Animator P2HUDAnim;
    public AudioSource music;
    public Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerStats.LoadPlayerStats();
        playerStats.LoadHighStakes();
        playerStats.LoadMusicPosition();
        

        print("Global Current Turn: " + playerStats.globalCurrentTurn);
        if (playerStats.globalCurrentTurn == 0)
        {
            playerStats.player1CurrentNode = 0;
            playerStats.player2CurrentNode = 0;


            playerStats.player1pos = players[0].transform.position;
            playerStats.player2pos = players[1].transform.position;

            playerStats.SavePlayerStats();
            playerStats.highStakes = false;
            playerStats.SaveHighStakes();

        }

        else
        {
            playerStats.LoadCameraPos();
            cameraTransform.position = playerStats.cameraPos;
            cameraTransform.rotation = playerStats.cameraRot;
            music.time = playerStats.musicTime;
            playerStats.highStakes = false;
            playerStats.SaveHighStakes();
            SetCurrentNode();
            SetCurrentPosition();
        }

        //Setting Each Anim and State Integers
        P1HUDAnim = P1HUD.GetComponent<Animator>();
        P1HUDAnim.SetInteger("State", 0);
        P2HUDAnim = P2HUD.GetComponent<Animator>();
        P2HUDAnim.SetInteger("State", 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerStats.p1Move < playerStats.p2Move)
        {
            if (currentPlayerTurn == 1 && !players[1].isMoving && !cardEvent)
            {
                // Include anim state change here
                P1HUDAnim.SetInteger("State", 0);
                P2HUDAnim.SetInteger("State", 1);
                players[1].CardMovePlus(playerStats.p2Move);
            }

            if (currentPlayerTurn == 2 && !players[0].isMoving && !cardEvent)
            {
                //Include anim state change here
                P2HUDAnim.SetInteger("State", 0);
                P1HUDAnim.SetInteger("State", 1);
                players[0].CardMovePlus(playerStats.p1Move);
            }
        }
        else
        {

            if (currentPlayerTurn == 1 && !players[0].isMoving && !cardEvent)
            {
                P2HUDAnim.SetInteger("State", 0);
                P1HUDAnim.SetInteger("State", 1);
                players[0].CardMovePlus(playerStats.p1Move);
            }

            if (currentPlayerTurn == 2 && !players[1].isMoving && !cardEvent)
            {
                P1HUDAnim.SetInteger("State", 0);
                P2HUDAnim.SetInteger("State", 1);
                players[1].CardMovePlus(playerStats.p2Move);
            }
        }
    }


    public void GetCurrentPosition()
    {
        playerStats.player1pos = players[0].transform.position;
        playerStats.player2pos = players[1].transform.position;
    }
    public void GetCurrentNode()
    {
        playerStats.player1CurrentNode = players[0].routePosition;
        playerStats.player2CurrentNode = players[1].routePosition;
    }

    public void SetCurrentPosition()
    {
        players[0].transform.position = playerStats.player1pos;
        players[1].transform.position = playerStats.player2pos;

    }
    public void SetCurrentNode()
    {
        players[0].routePosition = playerStats.player1CurrentNode;
        players[1].routePosition = playerStats.player2CurrentNode;
    }
}
