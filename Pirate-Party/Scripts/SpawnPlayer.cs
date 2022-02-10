using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SpawnPlayer : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameObject[] prefabs;
    private PlayerController[] playerControllers;

    public bool requireJump;
    public bool requireMash;
    public bool requireMove;

    // Start is called before the first frame update
    void Start()
    {
        playerStats.LoadPlayerStats();
        
        var player1ControlScheme = PlayerInput.Instantiate(prefab: prefabs[0], playerIndex: 0, controlScheme: "Keyboard - WASD", pairWithDevice: Keyboard.current);
        var player2ControlScheme = PlayerInput.Instantiate(prefab: prefabs[1], playerIndex: 1, controlScheme: "Keyboard - Arrow Keys", pairWithDevice: Keyboard.current);

        playerControllers = GameObject.FindObjectsOfType<PlayerController>();

        if(requireMash)
        {
            for (int i = 0; i < playerControllers.Length; i++)
            {
                playerControllers[i].buttonMashingGame = true;
            }
        }

        if (requireJump)
        {
            for (int i = 0; i < playerControllers.Length; i++)
            {
                playerControllers[i].jumpingGame = true;
            }
        }

        if (requireMove)
        {
            for (int i = 0; i < playerControllers.Length; i++)
            {
                playerControllers[i].movementGame = true;
            }
        }
    }
}
