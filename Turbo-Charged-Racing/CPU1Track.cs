using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU1Track : MonoBehaviour
{
    public GameObject marker;

    public GameObject waypoint1;
    public GameObject waypoint2;
    public GameObject waypoint3;
    public GameObject waypoint4;
    public GameObject waypoint5;
    public GameObject waypoint6;
    public GameObject waypoint7;
    public GameObject waypoint8;
    public GameObject waypoint9;
    public GameObject waypoint10;
    public GameObject waypoint11;
    public GameObject waypoint12;
    public GameObject waypoint13;
    public GameObject waypoint14;
    public GameObject waypoint15;
    public GameObject waypoint16;
    public GameObject waypoint17;
    public GameObject waypoint18;
    public GameObject waypoint19;


    public int markTracker;


    void Update()
    {
        if(markTracker == 0)
        {
            marker.transform.position = waypoint1.transform.position;
            marker.transform.rotation = waypoint1.transform.rotation;
        }
        if (markTracker == 1)
        {
            marker.transform.position = waypoint2.transform.position;
            marker.transform.rotation = waypoint2.transform.rotation;
        }
        if (markTracker == 2)
        {
            marker.transform.position = waypoint3.transform.position;
            marker.transform.rotation = waypoint3.transform.rotation;
        }
        if (markTracker == 3)
        {
            marker.transform.position = waypoint4.transform.position;
            marker.transform.rotation = waypoint4.transform.rotation;
        }
        if (markTracker == 4)
        {
            marker.transform.position = waypoint5.transform.position;
            marker.transform.rotation = waypoint5.transform.rotation;
        }
        if (markTracker == 5)
        {
            marker.transform.position = waypoint6.transform.position;
            marker.transform.rotation = waypoint6.transform.rotation;
        }
        if (markTracker == 6)
        {
            marker.transform.position = waypoint7.transform.position;
            marker.transform.rotation = waypoint7.transform.rotation;
        }
        if (markTracker == 7)
        {
            marker.transform.position = waypoint8.transform.position;
            marker.transform.rotation = waypoint8.transform.rotation;
        }
        if(markTracker == 8)
        {
            marker.transform.position = waypoint9.transform.position;
            marker.transform.rotation = waypoint9.transform.rotation;
        }
        if (markTracker == 9)
        {
            marker.transform.position = waypoint10.transform.position;
            marker.transform.rotation = waypoint10.transform.rotation;
        }
        if (markTracker == 10)
        {
            marker.transform.position = waypoint11.transform.position;
            marker.transform.rotation = waypoint11.transform.rotation;
        }
        if (markTracker == 11)
        {
            marker.transform.position = waypoint12.transform.position;
            marker.transform.rotation = waypoint12.transform.rotation;
        }
        if (markTracker == 12)
        {
            marker.transform.position = waypoint13.transform.position;
            marker.transform.rotation = waypoint13.transform.rotation;
        }
        if (markTracker == 13)
        {
            marker.transform.position = waypoint14.transform.position;
            marker.transform.rotation = waypoint14.transform.rotation;
        }
        if (markTracker == 14)
        {
            marker.transform.position = waypoint15.transform.position;
            marker.transform.rotation = waypoint15.transform.rotation;
        }
        if (markTracker == 15)
        {
            marker.transform.position = waypoint16.transform.position;
            marker.transform.rotation = waypoint16.transform.rotation;
        }
        if (markTracker == 16)
        {
            marker.transform.position = waypoint17.transform.position;
            marker.transform.rotation = waypoint17.transform.rotation;
        }
        if (markTracker == 17)
        {
            marker.transform.position = waypoint18.transform.position;
            marker.transform.rotation = waypoint18.transform.rotation;
        }
        if (markTracker == 18)
        {
            marker.transform.position = waypoint19.transform.position;
            marker.transform.rotation = waypoint19.transform.rotation;
        }
    }

    IEnumerator OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "CPU1")
        {
            this.GetComponent<BoxCollider>().enabled = false;
            markTracker += 1;
            if(markTracker == 19)
            {
                markTracker = 0;
            }
            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
