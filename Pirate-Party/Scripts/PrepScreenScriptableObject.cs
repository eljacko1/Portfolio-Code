using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PrepScreen", menuName = "ScriptableObjects/PrepScreen", order = 1)]
public class PrepScreenScriptableObject : ScriptableObject
{
    public string minigameName;
    public string minigameInstructions;

    public string controlsP1;
    public string controlsP2;

    public GameObject prepScreenPrefab;
}
