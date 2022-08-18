using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] spawnPos;
    public GameObject[] obstacle;
    private float timeToNextSpawn;
    public float maxTimeTilSpawn;
    public float decrementTimeSpacing;
    public float minSpacing;
    public GameObject star;
    private float timeToNextStar;
    public float maxTimeTilStar;
    private bool canBottomSpawn;
    private bool canMidSpawn;
    private bool canTopSpawn;
    private int randomObstacle;
    private bool isWave1;
    private bool isWave2;
    private bool isWave3;
    private bool isWave4;
    private bool isWave5;


    void Start()
    {
        canBottomSpawn = true;
        canMidSpawn = true;
        canTopSpawn = true;
    }

    void Update()
    {
        //Spawning obstacles
        if (Time.timeSinceLevelLoad <= 60)
        {
            isWave1 = true;
        }
        else if (Time.timeSinceLevelLoad > 60 && Time.timeSinceLevelLoad <= 90)
        {
            isWave1 = false;
            isWave2 = true;
        }
        else if (Time.timeSinceLevelLoad > 90 && Time.timeSinceLevelLoad <= 180)
        {
            isWave2 = false;
            isWave3 = true;
        }
        else if (Time.timeSinceLevelLoad > 180)
        {
            isWave3 = false;
            isWave4 = true;
        }


        if (isWave1)
        {
            if (timeToNextSpawn <= 0)
            {
                canTopSpawn = true;
                canMidSpawn = true;
                canBottomSpawn = true;
                int obstaclesAmount = Random.Range(1, 3);
                while (obstaclesAmount > 0)
                {
                    int randomPos = Random.Range(0, 5);
                    randomObstacle = Random.Range(0, 1);

                    if (randomPos == 0 && canTopSpawn)
                    {
                        Instantiate(obstacle[randomObstacle], spawnPos[randomPos].transform.position, Quaternion.identity);
                        canTopSpawn = false;
                        obstaclesAmount--;
                    }
                    else if (randomPos == 1 && canMidSpawn)
                    {
                        Instantiate(obstacle[randomObstacle], spawnPos[randomPos].transform.position, Quaternion.identity);
                        canMidSpawn = false;
                        obstaclesAmount--;
                    }
                    else if ((randomPos == 2 || randomPos == 3 || randomPos == 4) && canBottomSpawn)
                    {
                        Instantiate(obstacle[randomObstacle], spawnPos[2].transform.position, Quaternion.identity);
                        canBottomSpawn = false;
                        obstaclesAmount--;
                    }

                }
                timeToNextSpawn = maxTimeTilSpawn;
                if (maxTimeTilSpawn >= minSpacing)
                {
                    maxTimeTilSpawn -= decrementTimeSpacing;
                }

            }
            else
            {
                int randomiser = Random.Range(0, 2);
                if (randomiser == 0)
                {
                    timeToNextSpawn -= Time.deltaTime;
                }

            }
        }
        else if (isWave2)
        {
            if (timeToNextSpawn <= 0)
            {
                canTopSpawn = true;
                canMidSpawn = true;
                canBottomSpawn = true;
                int obstaclesAmount = Random.Range(1, 3);
                while (obstaclesAmount > 0)
                {
                    int randomPos = Random.Range(0, 5);
                    randomObstacle = Random.Range(0, 3);

                    if (randomPos == 0 && canTopSpawn)
                    {
                        Instantiate(obstacle[randomObstacle], spawnPos[randomPos].transform.position, Quaternion.identity);
                        canTopSpawn = false;
                        obstaclesAmount--;
                    }
                    else if (randomPos == 1 && canMidSpawn)
                    {
                        Instantiate(obstacle[randomObstacle], spawnPos[randomPos].transform.position, Quaternion.identity);
                        canMidSpawn = false;
                        obstaclesAmount--;
                    }
                    else if ((randomPos == 2 || randomPos == 3 || randomPos == 4) && canBottomSpawn)
                    {
                        Instantiate(obstacle[randomObstacle], spawnPos[2].transform.position, Quaternion.identity);
                        canBottomSpawn = false;
                        obstaclesAmount--;
                    }

                }
                timeToNextSpawn = maxTimeTilSpawn;
                if (maxTimeTilSpawn >= minSpacing)
                {
                    maxTimeTilSpawn -= decrementTimeSpacing;
                }

            }
            else
            {
                int randomiser = Random.Range(0, 2);
                if (randomiser == 0)
                {
                    timeToNextSpawn -= Time.deltaTime;
                }

            }
        }

        else if (isWave3)
        {
            if (timeToNextSpawn <= 0)
            {
                canTopSpawn = true;
                canMidSpawn = true;
                canBottomSpawn = true;
                int obstaclesAmount = Random.Range(1, 3);
                while (obstaclesAmount > 0)
                {
                    int randomPos = Random.Range(0, 5);
                    randomObstacle = Random.Range(0, 4);

                    if (randomPos == 0 && canTopSpawn)
                    {
                        Instantiate(obstacle[randomObstacle], spawnPos[randomPos].transform.position, Quaternion.identity);
                        canTopSpawn = false;
                        obstaclesAmount--;
                    }
                    else if (randomPos == 1 && canMidSpawn)
                    {
                        Instantiate(obstacle[randomObstacle], spawnPos[randomPos].transform.position, Quaternion.identity);
                        canMidSpawn = false;
                        obstaclesAmount--;
                    }
                    else if ((randomPos == 2 || randomPos == 3 || randomPos == 4) && canBottomSpawn)
                    {
                        Instantiate(obstacle[randomObstacle], spawnPos[2].transform.position, Quaternion.identity);
                        canBottomSpawn = false;
                        obstaclesAmount--;
                    }

                }
                timeToNextSpawn = maxTimeTilSpawn;
                if (maxTimeTilSpawn >= minSpacing)
                {
                    maxTimeTilSpawn -= decrementTimeSpacing;
                }

            }
            else
            {
                int randomiser = Random.Range(0, 2);
                if (randomiser == 0)
                {
                    timeToNextSpawn -= Time.deltaTime;
                }
            }
        }
        else if (isWave4)
        {
            if (timeToNextSpawn <= 0)
            {
                canTopSpawn = true;
                canMidSpawn = true;
                canBottomSpawn = true;
                int obstaclesAmount = Random.Range(1, 3);
                while (obstaclesAmount > 0)
                {
                    int randomPos = Random.Range(0, 5);
                    randomObstacle = Random.Range(0, 6);

                    if (randomPos == 0 && canTopSpawn)
                    {
                        Instantiate(obstacle[randomObstacle], spawnPos[randomPos].transform.position, Quaternion.identity);
                        canTopSpawn = false;
                        obstaclesAmount--;
                    }
                    else if (randomPos == 1 && canMidSpawn)
                    {
                        Instantiate(obstacle[randomObstacle], spawnPos[randomPos].transform.position, Quaternion.identity);
                        canMidSpawn = false;
                        obstaclesAmount--;
                    }
                    else if ((randomPos == 2 || randomPos == 3 || randomPos == 4) && canBottomSpawn)
                    {
                        Instantiate(obstacle[randomObstacle], spawnPos[2].transform.position, Quaternion.identity);
                        canBottomSpawn = false;
                        obstaclesAmount--;
                    }

                }
                timeToNextSpawn = maxTimeTilSpawn;
                if (maxTimeTilSpawn >= minSpacing)
                {
                    maxTimeTilSpawn -= decrementTimeSpacing;
                }

            }
            else
            {
                int randomiser = Random.Range(0, 2);
                if (randomiser == 0)
                {
                    timeToNextSpawn -= Time.deltaTime;
                }
            }
        }
    }
}


