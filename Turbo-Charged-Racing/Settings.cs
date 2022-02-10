using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public void MiniMapPreference(int preference)
    {
        PlayerPrefs.SetInt("MiniMapPosition", preference);
    }
}
