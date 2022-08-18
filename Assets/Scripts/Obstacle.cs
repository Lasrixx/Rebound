using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PlayerController playerScript;
    private float speed;
    public float maxSpeed;
    private bool forwardsRun;
    public AudioSource ball;
    public AudioClip splat;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerScript = GetComponent<PlayerController>();
        Vector2 region = transform.position;
        if (region.y > -6)
        {
            forwardsRun = true;
            spriteRenderer.color = Color.black;
        }
        else
        {
            forwardsRun = false;
            spriteRenderer.color = Color.white;
        }
    }

    void Update()
    {
        if (speed < maxSpeed)
        {
            speed = 4 + (Time.timeSinceLevelLoad / 50);
        }

        if (forwardsRun)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= -20)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= 20)
            {
                Destroy(gameObject);
            }
        }
    }
    public void Splat()
    {
        ball.PlayOneShot(splat);
    }
}
