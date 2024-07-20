using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private float speed;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        speed = 4.0f;
    }

    void Update()
    {
        float yVel = rb.velocity.y;

        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            anim.SetBool("isInAir", false);

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity += new Vector2(0, speed);
                anim.SetBool("isInAir", true);
                yVel = rb.velocity.y;
            }
        }
        else
        {
            anim.SetBool("isInAir", true);
        }

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(-speed, yVel);
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(speed, yVel);
            transform.localScale = Vector3.one;
            anim.SetBool("isWalking", true);
        }

        if ((Input.GetKeyUp(KeyCode.A) && !Input.GetKey(KeyCode.D)) ||
            (Input.GetKeyUp(KeyCode.D) && !Input.GetKey(KeyCode.A)))
        {
            rb.velocity = new Vector2(0, yVel);
            transform.localScale = Vector3.one;
            anim.SetBool("isWalking", false);
        }
    }
}
