using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private float speed;
    private bool forwardsRun;

    void Start()
    {
        Vector2 region = transform.position;
        if (region.y >= -6)
        {
            forwardsRun = true;
        }
        else
        {
            forwardsRun = false;
        }

        speed = 3 + (Time.timeSinceLevelLoad / 50);
    }

    
    void Update()
    {
        if (forwardsRun)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= -2)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= 2)
            {
                Destroy(gameObject);
            }
        }
    }
}
