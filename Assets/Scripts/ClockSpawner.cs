using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSpawner : MonoBehaviour
{
    public GameObject[] spawnPos;
    public float maxTimeTilClockSpawn;
    private float timeToClockSpawn;
    public GameObject clock;

    void Start()
    {
        
    }

    void Update()
    {
        if (timeToClockSpawn <= 0)
        {
            int spawnPosIndex = Random.Range(0, spawnPos.Length);
            Instantiate(clock, spawnPos[spawnPosIndex].transform.position, Quaternion.identity);
            timeToClockSpawn = maxTimeTilClockSpawn;
        }
        else
        {
            timeToClockSpawn -= Time.deltaTime;
        }
    }
}
