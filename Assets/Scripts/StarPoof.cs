using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPoof : MonoBehaviour
{
    private float timeToDestroy;

    void Start()
    {
        timeToDestroy = 2f;
    }

    void Update()
    {
        if (timeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            timeToDestroy -= Time.deltaTime;
        }
    }
}
