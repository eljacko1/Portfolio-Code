using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehaviour : MonoBehaviour
{
    //Initial Thrust for Missile
    public float Thrust = 700f;
    //The Missiles RigidBody
    private Rigidbody rb;
    private Transform tr;
    private GameObject minigameControllerGO;
    private CannonMinigameController minigameController;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.up * Thrust);
        tr = gameObject.GetComponent<Transform>();

        minigameControllerGO = GameObject.FindGameObjectWithTag("MinigameController");
        minigameController = minigameControllerGO.GetComponent<CannonMinigameController>();
    }


    void Update()
    {

    }

    // When Fired up, the missile collides with a trigger, it is then moved across slightly where it can fall onto the players
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trigger")
        {
            
           //Get Rigidbody and set velocity to (0f, 0f, 0f)
           rb.velocity = Vector3.zero;
           tr.transform.position = new Vector3(tr.position.x, tr.position.y, tr.position.z - 2);
        }
        // on collsion with Players
        if (other.gameObject.tag == "Player1")
        {
           minigameController.RemovePlayerOne();
           Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player2")
        {
            minigameController.RemovePlayerTwo();
            Destroy(gameObject);
        }
        //on collision with the ground
        if (other.gameObject.tag == "Ground")
        {

            Destroy(gameObject);
        }

    }
}
