using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarkersSystem : MonoBehaviour
{
    [SerializeField]
    Transform player1;
    [SerializeField]
    Transform player2;
    [SerializeField]
    Transform player1Marker;
    [SerializeField]
    Transform player2Marker;

    public float distanceThreshold;
    private float player1Distance;
    private float player2Distance;
    private float average;

    // Start is called before the first frame update
    void Start()
    {
        player1Marker.localScale = Vector3.zero;
        player2Marker.localScale = Vector3.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        CheckDistance();

        if(player1Distance > distanceThreshold || player2Distance > distanceThreshold)
        {
            AverageDistance();
        }

        ScaleMarkers();
    }

    void CheckDistance()
    {
        if(Vector3.Distance(player1.position, this.transform.position) > distanceThreshold)
        {
            player1Distance = Vector3.Distance(player1.position, this.transform.position);
        }
        else
        {
            player1Marker.localScale = Vector3.zero;
            player1Distance = 0;
        }

        if(Vector3.Distance(player2.position, this.transform.position) > distanceThreshold)
        {
            player2Distance = Vector3.Distance(player2.position, this.transform.position);
        }
        else
        {
            player2Marker.localScale = Vector3.zero;
            player2Distance = 0;
        }
    }

    void AverageDistance()
    {
        average = (player1Distance + player2Distance) / 2;
    }

    void ScaleMarkers()
    {

        if(player1Distance > distanceThreshold)
        {
            player1Marker.localScale = Vector3.one * average / 1000;
            player1Marker.position = new Vector3(player1Marker.position.x, (1 * average) / 12 + player1.position.y, player1Marker.position.z);
        }

        if (player2Distance > distanceThreshold)
        {
            player2Marker.localScale = Vector3.one * average / 1000;
            player2Marker.position = new Vector3(player2Marker.position.x, (1 * average) / 12 + player2.position.y, player2Marker.position.z);
        }


    }
}
