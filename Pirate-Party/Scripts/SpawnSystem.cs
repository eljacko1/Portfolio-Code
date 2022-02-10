using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnSystem : MonoBehaviour
{
    public List<GameObject> walls;
    public InvisibleTimer timer;

    [SerializeField]
    Transform spawnPoint;

    float spawnInterval;
    public float minInterval;
    public float maxInterval;
    float difficulty;
    public float wallMoveSpeed;

    void Start()
    {
        spawnInterval = 0;
        Shuffle(walls);
    }

    void Shuffle(List<GameObject> walls)
    {
        for (int i = walls.Count - 1; i > 0; i--)
        {
            int rnd = UnityEngine.Random.Range(0, i);

            GameObject temp = walls[i];

            walls[i] = walls[rnd];
            walls[rnd] = temp;
        }
    }

    void Update()
    {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval <= 0)
        {
            // Spawn a wall 
            if (walls.Count > 0)
            {
                Instantiate(walls[0], spawnPoint.position, spawnPoint.rotation);
                walls.Remove(walls[0]);
                ChangeInterval();
                spawnInterval = Random.Range(minInterval, maxInterval);
            }
        }
    }


    void ChangeInterval()
    {
        if (timer != null)
        {
            difficulty = difficulty + timer.time / 125;
        }

        if(wallMoveSpeed < 14)
        {
            wallMoveSpeed += 0.25f;
        }


        if (maxInterval > minInterval)
        {
            maxInterval = maxInterval - difficulty;
        }


        if (minInterval == maxInterval)
        {
            minInterval = maxInterval - 1f;
        }
    }
}
