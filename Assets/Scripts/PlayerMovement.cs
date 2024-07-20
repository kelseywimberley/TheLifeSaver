using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private float movementSpeed;
    private float jumpSpeed;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        movementSpeed = 4.0f;
        jumpSpeed = 5.0f;
    }

    void Update()
    {
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
            if (rb.velocity.x < 4.0f)
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
}
