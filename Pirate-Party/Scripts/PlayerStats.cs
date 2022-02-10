using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
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
    public void LoadPlayerStats()
    {
        p1Move = GlobalControl.Instance.p1Move;
        p2Move = GlobalControl.Instance.p2Move;

        player1CurrentNode = GlobalControl.Instance.player1CurrentNode;
        player2CurrentNode = GlobalControl.Instance.player2CurrentNode;

        player1pos = GlobalControl.Instance.player1pos;
        player2pos = GlobalControl.Instance.player2pos;

        globalCurrentTurn = GlobalControl.Instance.globalCurrentTurn;

        currentRegion = GlobalControl.Instance.currentRegion;
    }

    public void LoadHighStakes()
    {
        highStakes = GlobalControl.Instance.highStakes;
    }

    public void LoadCameraPos()
    {
        cameraPos = GlobalControl.Instance.cameraPos;
        cameraRot = GlobalControl.Instance.cameraRot;
    }

    public void LoadMusicPosition()
    {
        musicTime = GlobalControl.Instance.musicTime;
    }

    public void SavePlayerStats()
    {
        GlobalControl.Instance.p1Move = p1Move;
        GlobalControl.Instance.p2Move = p2Move;

        GlobalControl.Instance.player1CurrentNode = player1CurrentNode;
        GlobalControl.Instance.player2CurrentNode = player2CurrentNode;

        GlobalControl.Instance.player1pos = player1pos;
        GlobalControl.Instance.player2pos = player2pos;

        GlobalControl.Instance.globalCurrentTurn = globalCurrentTurn;

        GlobalControl.Instance.currentRegion = currentRegion;
    }

    public void SaveHighStakes()
    {
        GlobalControl.Instance.highStakes = highStakes;
    }

    public void SaveCameraPos()
    {
        GlobalControl.Instance.cameraPos = cameraPos;
        GlobalControl.Instance.cameraRot = cameraRot;
    }

    public void SaveMusicPosition()
    {
        GlobalControl.Instance.musicTime = musicTime;
    }

    public void InitialisePlayerStats()
    {
        print("Initialised");
        player1CurrentNode = 0;
        player2CurrentNode = 0;

        player1pos = new Vector3(0.71f, 1.74f, 27.84f);
        player2pos = new Vector3(0.16f, 1.74f, 27.317f);

        globalCurrentTurn = 0;

        SavePlayerStats();
    }
}
