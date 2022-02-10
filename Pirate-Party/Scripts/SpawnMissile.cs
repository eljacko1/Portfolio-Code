using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMissile : MonoBehaviour
{
    public GameObject Missile;
   // public GameObject VFX;
    [SerializeField]
    private Timer timer;

    float spawnInterval;
    float spawnIntervalMin = 2.0f;
    public float spawnIntervalMax = 6.0f;
    float difficulty;
    public AudioClip[] CannonNoise;
    public AudioSource AudioSource;

    void Start()
    {
        spawnInterval = Random.Range(0.5f, 2.0f);
        AudioSource.GetComponent<AudioSource>();
        AudioSource.clip = CannonNoise[Random.Range(0, CannonNoise.Length)];
    }

    void Update()
    {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval <= 0)
        {
            // Spawn a missile
           // VFX.SetActive(true);
            Instantiate(Missile, transform.position, transform.rotation);
            AudioSource.clip = CannonNoise[Random.Range(0, CannonNoise.Length)];
            AudioSource.Play();
            ChangeInterval();
            spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
           // VFX.SetActive(false);
        }
        
    }


    void ChangeInterval()
    {
        if(timer != null)
        {
            difficulty = difficulty + timer.timeRemaining / 150;
        }



        if(spawnIntervalMax > 1.0f)
        {
            spawnIntervalMax = spawnIntervalMax - difficulty;
        }        


        if(spawnIntervalMax == 1.0f)
        {
            spawnIntervalMin = 0.5f;
        }
    }
}
