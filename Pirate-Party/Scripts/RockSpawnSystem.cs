using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RockSpawnSystem : MonoBehaviour
{
    public List<GameObject> rocks;
    public InvisibleTimer timer;

    [SerializeField]
    Transform spawnPoint;

    float spawnInterval;
    public float maxSpawnInterval;
    public float wallMoveSpeed;

    void Start()
    {
        spawnInterval = 0;
        Shuffle(rocks);
    }

    void Shuffle(List<GameObject> rocks)
    {
        for (int i = rocks.Count - 1; i > 0; i--)
        {
            int rnd = UnityEngine.Random.Range(0, i);

            GameObject temp = rocks[i];

            rocks[i] = rocks[rnd];
            rocks[rnd] = temp;
        }
    }

    void Update()
    {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval <= 0)
        {
            // Spawn a wall 
            if (rocks.Count > 0)
            {
                Instantiate(rocks[0], spawnPoint.position, rocks[0].transform.rotation);
                Shuffle(rocks);
                spawnInterval = maxSpawnInterval;

            }
        }

    }
}
