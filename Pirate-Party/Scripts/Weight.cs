using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    public Vector3 distanceFromChainEnd;

    public void ConnectRopeEnd(Rigidbody endRB)
    {
        HingeJoint joint = gameObject.AddComponent<HingeJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = endRB;
        joint.anchor = Vector3.zero;
        joint.connectedAnchor = distanceFromChainEnd;
    }
}
