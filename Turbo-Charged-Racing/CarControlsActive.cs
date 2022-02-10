using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;


public class CarControlsActive : MonoBehaviour
{

    public GameObject CarControl;
    public GameObject AICar1;


    void Start()
    {
        CarController.m_Topspeed = 200;
        CarControl.GetComponent<CarUserControl>().enabled = true;
        AICar1.GetComponent<CarController>().enabled = true;
    }
}