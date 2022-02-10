using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    //Initial Thrust for Missile
    public float Thrust = 400f;
    //The Missiles RigidBody
    private Rigidbody rb;
    private Transform tr;
    private RaceMinigameController minigameController;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.right * -1 * Thrust);
        tr = gameObject.GetComponent<Transform>();

        minigameController = FindObjectOfType<RaceMinigameController>();
    }


    void Update()
    {

    }

    // When Fired up, the missile collides with a trigger, it is then moved across slightly where it can fall onto the players
    private void OnTriggerEnter(Collider other)
    {

        //on collision with the Obstacle game object (Need to add tag "Obstacle")
        if (other.gameObject.tag == "Obstacle")
        {

            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player1")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player2")
        {
            Destroy(gameObject);
        }

    }
}
