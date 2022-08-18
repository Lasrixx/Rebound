using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{

    public GameObject star;
    public float maxTimeTilStar;
    private float timeToNextStar;
    public GameObject[] spawnPos;

    void Start()
    {
        
    }

    void Update()
    {
        if (timeToNextStar <= 0)
        {
            int starAmount = 1;
            while (starAmount > 0)
            {
                int randomStarPos = Random.Range(0, 6);
                Instantiate(star, spawnPos[randomStarPos].transform.position, Quaternion.identity);
                starAmount--;
            }
            timeToNextStar = maxTimeTilStar;
        }
        else
        {
            int randomiser = Random.Range(0, 2);
            if (randomiser == 0)
            {
                timeToNextStar -= Time.deltaTime;
            }
        }
    }
}
