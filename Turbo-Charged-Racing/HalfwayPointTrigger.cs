using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfwayPointTrigger : MonoBehaviour
{
    public GameObject lapCompleteTrigger;
    public GameObject halfLapTrigger;


    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player1")
        {
            lapCompleteTrigger.SetActive(true);
            halfLapTrigger.SetActive(false);
        }
    }
}