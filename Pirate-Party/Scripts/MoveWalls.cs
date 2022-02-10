using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalls : MonoBehaviour
{
    
    private GameObject endpoint;
    private SpawnSystem spawnSystem;

    // Start is called before the first frame update
    void Start()
    {
        endpoint = GameObject.FindGameObjectWithTag("Trigger");
        spawnSystem = GameObject.FindObjectOfType<SpawnSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, endpoint.transform.position.z), spawnSystem.wallMoveSpeed * Time.deltaTime);
    }
}
