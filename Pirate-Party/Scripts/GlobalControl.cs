using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{

    public static GlobalControl Instance;

    public int p1Move;
    public int p2Move;

    public int player1CurrentNode;
    public int player2CurrentNode;


    public Vector3 player1pos;
    public Vector3 player2pos;

    public float musicTime;

    public int globalCurrentTurn;

    public int currentRegion;

    public bool highStakes;

    public Vector3 cameraPos;
    public Quaternion cameraRot;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }


}
