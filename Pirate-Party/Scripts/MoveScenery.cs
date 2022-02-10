using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScenery : MonoBehaviour
{
    
    private GameObject endpoint;
    private ScenerySpawnSystem spawnSystem;

    // Start is called before the first frame update
    void Start()
    {
        endpoint = GameObject.FindGameObjectWithTag("Trigger");
        spawnSystem = GameObject.FindObjectOfType<ScenerySpawnSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, endpoint.transform.position.z), spawnSystem.wallMoveSpeed * Time.deltaTime);
    }
}
