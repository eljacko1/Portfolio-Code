using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScenerySpawnSystem : MonoBehaviour
{
    public List<GameObject> scenery;
    public InvisibleTimer timer;

    [SerializeField]
    Transform spawnPoint;

    float spawnInterval;
    public float maxSpawnInterval;
    public float wallMoveSpeed;

    void Start()
    { 
        spawnInterval = 0;
        Shuffle(scenery);
    }

    void Shuffle(List<GameObject> scenery)
    {
        for (int i = scenery.Count - 1; i > 0; i--)
        {
            int rnd = UnityEngine.Random.Range(0, i);

            GameObject temp = scenery[i];

            scenery[i] = scenery[rnd];
            scenery[rnd] = temp;
        }
    }

    void Update()
    {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval <= 0)
        {
            // Spawn a wall 
            if (scenery.Count > 0)
            {
                Instantiate(scenery[0], spawnPoint.position, scenery[0].transform.rotation);
                scenery.Remove(scenery[0]);
                spawnInterval = maxSpawnInterval;
                
            }
        }

    }
}
