using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBarrel : MonoBehaviour
{
    public GameObject Barrel;

    float spawnInterval;
    float spawnIntervalMin = 2.0f;
    public float spawnIntervalMax = 6.0f;
  

    void Start()
    {
        spawnInterval = Random.Range(2.0f, 6.0f);
    }

    void Update()
    {   
        spawnInterval -= Time.deltaTime;
        if (spawnInterval <= 0)
        { 
            // Spawn a missile
            Instantiate(Barrel, transform.position, transform.rotation);
            spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
        }
        
    }

    void OnTriggerEnter(Collider Other)
    {
        if(Other.tag == "Player1Body" || Other.tag == "Player2Body")
        {
            Destroy(gameObject);
        }
    }
}
