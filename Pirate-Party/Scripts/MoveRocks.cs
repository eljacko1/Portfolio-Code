using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocks : MonoBehaviour
{

    private GameObject endpoint;
    private RockSpawnSystem spawnSystem;

    // Start is called before the first frame update
    void Start()
    {
        endpoint = GameObject.FindGameObjectWithTag("Trigger");
        spawnSystem = GameObject.FindObjectOfType<RockSpawnSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, endpoint.transform.position.z), spawnSystem.wallMoveSpeed * Time.deltaTime);
    }
}
