using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public GameObject countdown;
    public AudioSource getReadyAudio;
    public AudioSource goAudio;
    public AudioSource levelMusic;
    public GameObject lapTimer;
    public GameObject carControls;

    public GameObject miniMapRight;
    public GameObject miniMapLeft;
    private int miniMapLocation;

    public int maxLapCount;
    public GameObject maxLapCounter;

    void Start()
    {
        maxLapCounter.GetComponent<Text>().text = "" + maxLapCount;
        miniMapLocation = PlayerPrefs.GetInt("MiniMapPosition");
        SetMiniMapLocation();
        StartCoroutine(CountStart());
    }

    private void SetMiniMapLocation()
    {
        if (miniMapLocation == 0)
        {
            miniMapLeft.SetActive(false);
            miniMapRight.SetActive(true);
        }
        else if (miniMapLocation == 1)
        {
            miniMapLeft.SetActive(true);
            miniMapRight.SetActive(false);
        }
        else if (miniMapLocation == 2)
        {
            miniMapLeft.SetActive(false);
            miniMapRight.SetActive(false);
        }
    }

    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);
        countdown.GetComponent<Text>().text = "3";
        getReadyAudio.Play();
        countdown.SetActive(true);
        yield return new WaitForSeconds(1);
        countdown.SetActive(false);
        countdown.GetComponent<Text>().color = new Color(255, 255, 0);
        countdown.GetComponent<Text>().text = "2";
        getReadyAudio.Play();
        countdown.SetActive(true);
        yield return new WaitForSeconds(1);
        countdown.SetActive(false);
        countdown.GetComponent<Text>().color = new Color(0, 255, 0);
        countdown.GetComponent<Text>().text = "1";
        getReadyAudio.Play();
        countdown.SetActive(true);
        yield return new WaitForSeconds(1);
        countdown.SetActive(false);
        goAudio.Play();
        levelMusic.Play();
        lapTimer.SetActive(true);
        carControls.SetActive(true);
    }
}
