using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLapTime : MonoBehaviour
{
    public int minCount;
    public int secCount;
    public float milliCount;

    public GameObject minDisplay;
    public GameObject secDisplay;
    public GameObject milliDisplay;

    void Start()
    {
        minCount = PlayerPrefs.GetInt("MinSave");
        minDisplay.GetComponent<Text>().text = "" + minCount + ":";

        secCount = PlayerPrefs.GetInt("SecSave");
        secDisplay.GetComponent<Text>().text = "" + secCount + ".";

        milliCount = PlayerPrefs.GetFloat("MilliSave");
        milliDisplay.GetComponent<Text>().text = "" + milliCount;

    }

}
