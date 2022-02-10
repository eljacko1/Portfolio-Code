using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody hook;
    public GameObject ropeLinkPrefab;
    public int links = 7;
    public Vector3 anchorPoint;
    private Weight weight;

    // Start is called before the first frame update
    void Start()
    {
        weight = FindObjectOfType<Weight>();
        weight.distanceFromChainEnd = anchorPoint;
        GenerateRope();
    }

    void GenerateRope()
    {
        Rigidbody prevRB = hook;
        for (int i = 0; i < links; i++)
        {
            GameObject link = Instantiate(ropeLinkPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
            HingeJoint joint = link.GetComponent<HingeJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = anchorPoint;
            joint.connectedBody = prevRB;


            if(i < links - 1)
            {
                prevRB = link.GetComponent<Rigidbody>();
            }
            else
            {
                weight.ConnectRopeEnd(link.GetComponent<Rigidbody>());
            }
        }

    }

}
