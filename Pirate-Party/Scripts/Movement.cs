using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Movement : MonoBehaviour
{
    public int routePosition;
    public Route currentRoute;
    public int steps;
    public bool isMoving;
    public PlayerManager playerManager;
    public InitialiseMinigame minigame;
    private CardSystem cardSystem;
    bool cardDelay;

    public TextMeshProUGUI playerMoveCounter;


    int tempPlayer1Node;
    int tempPlayer2Node;

    [SerializeField]
    private int delay;

    private void Start()
    {
        cardSystem = FindObjectOfType<CardSystem>();
    }

    //Update loop to make sure that the move counter is up to date
    private void Update()
    {
        playerMoveCounter.text = "Moves Left: " + steps;
    }

    //Function called by the card system when a move forwards card is triggered
    public void CardMovePlus(int numberOfSteps)
    {
        playerManager.movementMode = 0;
        steps = numberOfSteps;
        StartCoroutine(Move());
    }

    //Function called by the card system when a move backwards card is triggered
    public void CardMoveMinus(int numberOfSteps)
    {
        playerManager.movementMode = 1;
        steps = numberOfSteps;
        StartCoroutine(Move());
    }

    //Function called by the card system when a move to card is triggered
    public void CardMoveToPlayer()
    {
        tempPlayer1Node = playerManager.players[0].routePosition;
        tempPlayer2Node = playerManager.players[1].routePosition;
        playerManager.players[0].StopAllCoroutines();
        playerManager.players[1].StopAllCoroutines();

        playerManager.players[0].steps = 0;
        playerManager.players[1].steps = 0;

        playerMoveCounter.text = "Moves Left: " + steps;
        StartCoroutine(MoveToPlayer(5));
    }

    //Function called by the card system when a swap players card is triggered
    public void CardSwapPlayer()
    {
        tempPlayer1Node = playerManager.players[0].routePosition;
        tempPlayer2Node = playerManager.players[1].routePosition;

        playerManager.players[0].steps = 0;
        playerManager.players[1].steps = 0;

        playerMoveCounter.text = "Moves Left: " + steps;

        StopAllCoroutines();
        StartCoroutine(SwapPlayers(3));        
    }

    //Coroutine for the swap players card effect
    IEnumerator SwapPlayers(float time)
    {
        yield return new WaitForSeconds(delay);

        Vector3 currentPos1 = new Vector3(playerManager.players[0].currentRoute.childNodeList[playerManager.players[0].routePosition].position.x, playerManager.players[0].currentRoute.childNodeList[playerManager.players[0].routePosition].position.y + 5, playerManager.players[0].currentRoute.childNodeList[playerManager.players[0].routePosition].position.z);
        Vector3 currentPos2 = new Vector3(playerManager.players[1].currentRoute.childNodeList[playerManager.players[1].routePosition].position.x, playerManager.players[1].currentRoute.childNodeList[playerManager.players[1].routePosition].position.y + 5, playerManager.players[1].currentRoute.childNodeList[playerManager.players[1].routePosition].position.z);

        Vector3 nextPos1 = new Vector3(playerManager.players[0].currentRoute.childNodeList[tempPlayer2Node].position.x, playerManager.players[0].currentRoute.childNodeList[tempPlayer2Node].position.y + 5, playerManager.players[0].currentRoute.childNodeList[tempPlayer2Node].position.z);
        Vector3 nextPos2 = new Vector3(playerManager.players[1].currentRoute.childNodeList[tempPlayer1Node].position.x, playerManager.players[1].currentRoute.childNodeList[tempPlayer1Node].position.y + 5, playerManager.players[1].currentRoute.childNodeList[tempPlayer1Node].position.z);

        Vector3 finalPos1 = playerManager.players[0].currentRoute.childNodeList[playerManager.players[0].routePosition].position;
        Vector3 finalPos2 = playerManager.players[1].currentRoute.childNodeList[playerManager.players[1].routePosition].position;

        //Move Players Up
        float i = 0;
        while (i < 1)
        {
            i += Time.deltaTime / 2;

            playerManager.players[0].transform.position = Vector3.Lerp(playerManager.players[0].transform.position, currentPos1, i);
            playerManager.players[1].transform.position = Vector3.Lerp(playerManager.players[1].transform.position, currentPos2, i);
            yield return 0;
        }


        //Swap Player Positions
        i = 0;
        while (i < 1)
        {
            i += Time.deltaTime / time;
           
            playerManager.players[0].transform.position = Vector3.Lerp(currentPos1, nextPos1, i);
            playerManager.players[1].transform.position = Vector3.Lerp(currentPos2, nextPos2, i);
            yield return 0;
        }


        playerManager.players[0].routePosition = tempPlayer2Node;
        playerManager.players[1].routePosition = tempPlayer1Node;

        //Move Players Down
        i = 0;
        while (i < 1)
        {
            i += Time.deltaTime;

            playerManager.players[0].transform.position = Vector3.Lerp(nextPos1, finalPos2, i);
            playerManager.players[1].transform.position = Vector3.Lerp(nextPos2, finalPos1, i);
            yield return 0;
        }
        playerManager.player1Anim.SetBool("Dangling", false);
        playerManager.player2Anim.SetBool("Dangling", false);
        yield return new WaitForSeconds(delay);
        isMoving = false;

        CheckTurn();
    }

    //Coroutine for the Move to Player card effect
    IEnumerator MoveToPlayer(float time)
    {
        yield return new WaitForSeconds(delay);
        Vector3 currentPos = new Vector3(currentRoute.childNodeList[routePosition].position.x, currentRoute.childNodeList[routePosition].position.y + 5, currentRoute.childNodeList[routePosition].position.z);

        //If Player 1 triggers the card then player 2 is moved to the space that player 1 is on
        if (cardSystem.affectedPlayer == 1)
        {
            Vector3 nextPos = new Vector3(currentRoute.childNodeList[tempPlayer1Node].position.x, currentRoute.childNodeList[tempPlayer1Node].position.y + 5, currentRoute.childNodeList[tempPlayer1Node].position.z);
            Vector3 finalPos = playerManager.players[1].currentRoute.childNodeList[playerManager.players[0].routePosition].position;

            //Lift Player
            float i = 0;
            while (i < 1)
            {
                i += Time.deltaTime / 2;

                transform.position = Vector3.Lerp(transform.position, currentPos, i);
                yield return 0;
            }

            //Move Player
            i = 0;
            while (i < 1)
            {
                i += Time.deltaTime / time;

                transform.position = Vector3.Lerp(currentPos, nextPos, i);
                yield return 0;
            }

            //Lower Player
            i = 0;
            while (i < 1)
            {
                i += Time.deltaTime;

                transform.position = Vector3.Lerp(nextPos, finalPos, i);
                yield return 0;
            }


            routePosition = tempPlayer1Node;   
        }

        //If Player 2 triggers the card, player 1 is moved to the space that player 2 is on
        else if (cardSystem.affectedPlayer == 2)
        {
            Vector3 nextPos = new Vector3(currentRoute.childNodeList[tempPlayer2Node].position.x, currentRoute.childNodeList[tempPlayer2Node].position.y + 5, currentRoute.childNodeList[tempPlayer2Node].position.z);
            Vector3 finalPos = playerManager.players[0].currentRoute.childNodeList[playerManager.players[1].routePosition].position;

            //Raise Player
            float i = 0;
            while (i < 1)
            {
                i += Time.deltaTime / 2;

                transform.position = Vector3.Lerp(transform.position, currentPos, i);
                yield return 0;
            }

            //Move Player
            i = 0;
            while (i < 1)
            {
                i += Time.deltaTime / time;

                transform.position = Vector3.Lerp(currentPos, nextPos, i);
                yield return 0;
            }

            //Lower Player
            i = 0;
            while (i < 1)
            {
                i += Time.deltaTime;

                transform.position = Vector3.Lerp(nextPos, finalPos, i);
                yield return 0;
            }
            routePosition = tempPlayer2Node;
        }
        playerManager.player1Anim.SetBool("Dangling", false);
        playerManager.player2Anim.SetBool("Dangling", false);

        yield return new WaitForSeconds(delay);
        isMoving = false;

        CheckTurn();
    }

    //Coroutine for the main Movement of the players including the move forward and move backward card effects
    private IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }

        isMoving = true;


        while (steps > 0)
        {
            if (playerManager.cardEvent && cardDelay == false)
            {
                cardDelay = true;
                yield return new WaitForSeconds(3);
            }

            //Move Forward
            if (playerManager.movementMode == 0)
            {
                routePosition++;

                if (routePosition >= currentRoute.childNodeList.Count)
                {
                    yield break;
                }

                Vector3 nextPos = currentRoute.childNodeList[routePosition].position;
                while (MoveToNextNode(nextPos)) { yield return null; }


                steps--;
            }

            //Move Backward
            else if (playerManager.movementMode == 1)
            {
                routePosition--;
                if (routePosition >= currentRoute.childNodeList.Count)
                {
                    yield break;
                }

                Vector3 nextPos = currentRoute.childNodeList[routePosition].position;
                while (MoveToNextNode(nextPos)) { yield return null; }


                steps--;
            }
        }

        yield return new WaitForSeconds(delay);
        isMoving = false;

        CheckTurn();
    }

    //Function to check if the player is at the target node, stopping the main movement coroutine if it is
    bool MoveToNextNode(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, 2.5f * Time.deltaTime));
    }

    //Function to check whether to go to a minigame and to save stats and other important information
    void CheckTurn()
    {
        if (playerManager.currentPlayerTurn == 2)
        {
            playerManager.playerStats.globalCurrentTurn += 1;

            playerManager.GetCurrentNode();
            playerManager.GetCurrentPosition();

            playerManager.playerStats.SavePlayerStats();
            playerManager.playerStats.SaveHighStakes();
            playerManager.playerStats.cameraPos = playerManager.cameraTransform.position;
            playerManager.playerStats.cameraRot = playerManager.cameraTransform.rotation;
            playerManager.playerStats.SaveCameraPos();

            playerManager.playerStats.musicTime = playerManager.music.time;
            playerManager.playerStats.SaveMusicPosition();
            cardDelay = false;
            minigame.StartMinigame();
        }
        else { playerManager.currentPlayerTurn += 1; }
    }

}
