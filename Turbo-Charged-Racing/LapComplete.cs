using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;


public class LapComplete : MonoBehaviour
{
    public GameObject lapCompleteTrigger;
    public GameObject halfLapTrigger;

    public GameObject minuteDisplay;
    public GameObject secondDisplay;
    public GameObject milliDisplay;

    public GameObject currentLapCounter;
    public int currentLapCount;
    public GameObject maxLaps;
    public GameObject raceFinish;
    public GameObject myCar;

    public Sprite noBoost;
    public Sprite oneBoost;
    public Sprite twoBoosts;
    public Sprite threeBoosts;
    public Image boostSprite;

    public float rawTime;


    private void OnTriggerEnter(Collider collider)
    {


        if (collider.tag == "Player1")
        {
            rawTime = PlayerPrefs.GetFloat("RawTime");
            if (LapTimeManager.rawTime <= rawTime)
            {

                if (LapTimeManager.secondCount <= 9)
                {
                    secondDisplay.GetComponent<Text>().text = "0" + LapTimeManager.secondCount + ".";
                }

                else
                {
                    secondDisplay.GetComponent<Text>().text = "" + LapTimeManager.secondCount + ".";
                }


                if (LapTimeManager.minuteCount <= 9)
                {
                    minuteDisplay.GetComponent<Text>().text = "0" + LapTimeManager.minuteCount + ":";
                }
                else
                {
                    minuteDisplay.GetComponent<Text>().text = "" + LapTimeManager.minuteCount + ":";
                }

                milliDisplay.GetComponent<Text>().text = "" + LapTimeManager.milliCount;


                if (LapTimeManager.minuteCount >= 59)
                {
                    milliDisplay.GetComponent<Text>().text = "--";
                    secondDisplay.GetComponent<Text>().text = "--" + ".";
                    minuteDisplay.GetComponent<Text>().text = "--" + ":";
                }
            }


            PlayerPrefs.SetInt("MinSave", LapTimeManager.minuteCount);
            PlayerPrefs.SetInt("SecSave", LapTimeManager.secondCount);
            PlayerPrefs.SetFloat("MilliSave", LapTimeManager.milliCount);
            PlayerPrefs.SetFloat("RawTime", LapTimeManager.rawTime);



            LapTimeManager.minuteCount = 0;
            LapTimeManager.secondCount = 0;
            LapTimeManager.milliCount = 0;
            LapTimeManager.rawTime = 0;

            currentLapCount++;
            currentLapCounter.GetComponent<Text>().text = "" + currentLapCount;

            lapCompleteTrigger.SetActive(false);
            halfLapTrigger.SetActive(true);

            if (myCar.GetComponent<CarUserControl>().boostLeft != 3)
            {
                myCar.GetComponent<CarUserControl>().boostLeft += 1;
            }

            if (myCar.GetComponent<CarUserControl>().boostLeft == 0)
            {
                boostSprite = this.GetComponent<Image>();
                boostSprite.sprite = noBoost;
            }
            else if (myCar.GetComponent<CarUserControl>().boostLeft == 1)
            {
                boostSprite.sprite = oneBoost;
            }
            else if (myCar.GetComponent<CarUserControl>().boostLeft == 2)
            {
                boostSprite.sprite = twoBoosts;
            }
            else if (myCar.GetComponent<CarUserControl>().boostLeft == 3)
            {
                boostSprite.sprite = threeBoosts;
            }


            if (currentLapCount > maxLaps.GetComponent<Countdown>().maxLapCount)
            {
                myCar.GetComponent<CarUserControl>().boostLeft = 0;
                currentLapCounter.GetComponent<Text>().text = "" + (currentLapCount - 1);
                raceFinish.SetActive(true);
            }
        }
    }
}


