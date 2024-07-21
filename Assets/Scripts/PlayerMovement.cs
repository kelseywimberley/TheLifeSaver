using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private float movementSpeed;
    private float jumpSpeed;
    private int health;
    private bool hurt;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public GameObject pausedText;
    public GameObject resumeButton;
    public GameObject quitButton;
    public GameObject pauseBackground;
    private bool paused;
    private bool gameOver;
    private bool escape;
    private bool dead;
    private float timer;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        movementSpeed = 4.0f;
        jumpSpeed = 5.0f;
        health = 3;
        escape = true;
        timer = 0.0f;
    }

    void Update()
    {
        if (gameOver)
        {
            if (dead)
            {
                timer += Time.deltaTime;
                if (timer > 1.0f)
                {
                    SceneManager.LoadScene("Level");
                }

                transform.Rotate(0, 0, 15.0f * Time.deltaTime);

                return;
            }

            timer += Time.deltaTime;
            if (timer > 2.0f)
            {
                SceneManager.LoadScene("Menu");
            }

            if (escape)
            {
                rb.velocity = new Vector2(movementSpeed, 0);
                transform.position = new Vector3(transform.position.x, -8.39f, 0);
            }
            else
            {
                rb.velocity = new Vector2(-movementSpeed, 0);
                transform.position = new Vector3(transform.position.x, 4.52f, 0);
            }

            return;
        }

        if (paused)
        {
            return;
        }

        if (hurt)
        {
            timer += Time.deltaTime;
            if (timer > 1.5f)
            {
                hurt = false;
                timer = 0.0f;
            }
        }

        if (Input.GetKey(KeyCode.Escape) && !paused)
        {
            paused = true;
            Time.timeScale = 0.0f;
            pausedText.SetActive(true);
            resumeButton.SetActive(true);
            quitButton.SetActive(true);
            pauseBackground.SetActive(true);
        }

        float yVel = rb.velocity.y + Physics.gravity.y * Time.deltaTime;

        // Horizontal Movement
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x > -movementSpeed)
            {
                rb.velocity += new Vector2(-movementSpeed - rb.velocity.x, 0);
            }
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x < movementSpeed)
            {
                rb.velocity += new Vector2(movementSpeed - rb.velocity.x, 0);
            }
            anim.SetBool("isWalking", true);
        }

        if ((Input.GetKeyUp(KeyCode.A) && !Input.GetKey(KeyCode.D)) ||
            (Input.GetKeyUp(KeyCode.D) && !Input.GetKey(KeyCode.A)))
        {
            rb.velocity -= new Vector2(rb.velocity.x * 0.99f, 0);
            anim.SetBool("isWalking", false);
        }

        // Vertical Movement
        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            anim.SetBool("isInAir", false);

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity += new Vector2(0, jumpSpeed);
                anim.SetBool("isInAir", true);
                yVel = rb.velocity.y;
            }
        }
        else
        {
            anim.SetBool("isInAir", true);
        }
    }

    public void UnpauseGame()
    {
        paused = false;
        Time.timeScale = 1.0f;
        pausedText.SetActive(false);
        resumeButton.SetActive(false);
        quitButton.SetActive(false);
        pauseBackground.SetActive(false);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Home")
        {
            if (Camera.main.GetComponent<BatAndMouseTracking>().CheckWinCondition())
            {
                gameOver = true;
                escape = false;
                timer = 0.0f;

                anim.SetBool("isInAir", false);
                anim.SetBool("isWalking", true);
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0.0f;
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        if (collision.tag == "Escape")
        {
            gameOver = true;
            escape = true;
            timer = 0.0f;

            anim.SetBool("isInAir", false);
            anim.SetBool("isWalking", true);
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0.0f;
            GetComponent<BoxCollider2D>().enabled = false;
        }

        if (collision.tag == "Enemy" && !hurt)
        {
            hurt = true;
            health--;
            timer = 0.0f;

            if (health == 2)
            {
                heart3.SetActive(false);
            }
            if (health == 1)
            {
                heart2.SetActive(false);
            }
            if (health == 0)
            {
                heart1.SetActive(false);
                gameOver = true;
                dead = true;
            }
        }

        if (collision.tag == "Attack" && !hurt)
        {
            Destroy(collision.gameObject);
            hurt = true;
            health--;
            timer = 0.0f;

            if (health == 2)
            {
                heart3.SetActive(false);
            }
            if (health == 1)
            {
                heart2.SetActive(false);
            }
            if (health == 0)
            {
                heart1.SetActive(false);
                gameOver = true;
                dead = true;
            }
        }
    }
}
