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

    public GameObject pausedText;
    public GameObject resumeButton;
    public GameObject quitButton;
    public GameObject pauseBackground;
    private bool paused;
    private bool gameOver;
    private bool escape;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        movementSpeed = 4.0f;
        jumpSpeed = 5.0f;
        escape = true;
    }

    void Update()
    {
        if (gameOver)
        {
            if (escape)
            {
                if (rb.velocity.x < movementSpeed)
                {
                    rb.velocity += new Vector2(movementSpeed - rb.velocity.x, 0);
                }
            }
            else
            {
                if (rb.velocity.x > -movementSpeed)
                {
                    rb.velocity += new Vector2(-movementSpeed - rb.velocity.x, 0);
                }
            }

            return;
        }

        if (paused)
        {
            return;
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
        
    }
}
