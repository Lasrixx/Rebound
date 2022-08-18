using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public AudioSource ball;
    public AudioClip thud;
    public AudioClip splat;
    public AudioClip starBurst;
    private bool canMakeNoise;
    private bool forwardsRun;
    public Score scoreScript;
    private bool touchingFloor;
    public float jumpVelocity;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    private bool endGame = false;
    public float timeToRestart = 2f;
    public Obstacle obstacleScript;
    public ParticleSystem forwardsSplat;
    public ParticleSystem backwardsSplat;
    private float rotationSpeed;
    public ParticleSystem starPoof;
    public TransitionsManager transitionsManager;

    private void Awake()
    {
        canMakeNoise = false;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Vector2 region = transform.position;

        if (region.y > -6)
        {
            forwardsRun = true;
        }
        else
        {
            forwardsRun = false;
        }
        
    }

    void Update()
    {

        if (Time.timeSinceLevelLoad < 1)
        {
            canMakeNoise = false;
        }
        else
        {
            canMakeNoise = true;
        }


        rotationSpeed = 4 + (Time.timeSinceLevelLoad / 50);

        if (forwardsRun)
        {
            transform.Rotate(0f, 0f, -(rotationSpeed));
            if (Input.GetKey(KeyCode.Q) && touchingFloor)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            }
        }
        else
        {
            transform.Rotate(0f, 0f, rotationSpeed);
            if (Input.GetKey(KeyCode.P) && touchingFloor)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            }
        }
        BetterJump();

        if (endGame == true)
        {
            if (timeToRestart <= 0)
            {
                transitionsManager.ReloadLevel();
                //RestartGame();
            }
            else
            {
                timeToRestart -= Time.deltaTime;
            }
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void FixedUpdate()
    {
        LayerMask layer = LayerMask.GetMask("Obstacles");

        if (forwardsRun)
        {
            RaycastHit2D checkForObstacle = Physics2D.Raycast(transform.position, Vector2.right, 0.6f, layer);

            if (checkForObstacle.collider != null)
            {
                ball.PlayOneShot(splat);
                spriteRenderer.enabled = false;
                Instantiate(forwardsSplat, transform.position, Quaternion.identity);
                endGame = true;
                
            }
        }
        else
        {
            RaycastHit2D checkForObstacle = Physics2D.Raycast(transform.position, Vector2.left, 0.51f, layer);

            if (checkForObstacle.collider != null)
            {
                ball.PlayOneShot(splat);
                spriteRenderer.enabled = false;
                Instantiate(backwardsSplat, transform.position, Quaternion.identity);
                endGame = true;    
                
            }
        }
        RaycastHit2D checkForScoreUp = Physics2D.Raycast(transform.position, Vector2.up, 10f, layer);
        RaycastHit2D checkForScoreDown = Physics2D.Raycast(transform.position, Vector2.down, 10f, layer);
        if (checkForScoreUp.collider != null)
        {
            scoreScript.UpdateScore();
        }
        if(checkForScoreDown.collider != null)
        {
            scoreScript.UpdateScore();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            touchingFloor = true;
            if (canMakeNoise == true)
            {
                ball.PlayOneShot(thud);
            }

        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            touchingFloor = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Star")
        {
            scoreScript.CaughtStar();
            ball.PlayOneShot(starBurst);
            Instantiate(starPoof, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);

        }
    }

    void BetterJump()
    {
        if (forwardsRun)
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Q))
            {
                rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
        else
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.P))
            {
                rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
    }
}
