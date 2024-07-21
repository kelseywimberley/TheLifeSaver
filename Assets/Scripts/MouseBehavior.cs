using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehavior : MonoBehaviour
{
    private bool good;
    public Sprite goodSprite;
    public Vector3 leftPos;
    public Vector3 rightPos;
    private bool goingLeft;
    private float speed;
    private Transform playerTransform;

    void Start()
    {
        good = false;
        goingLeft = true;
        speed = 2.0f;
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (!good)
        {
            if (goingLeft)
            {
                if (Vector3.Distance(leftPos, transform.position) < 0.03f)
                {
                    goingLeft = false;
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else
                {
                    transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                }
            }
            else
            {
                if (Vector3.Distance(rightPos, transform.position) < 0.03f)
                {
                    goingLeft = true;
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                }
            }
        }
        else
        {
            // Face Player
            if (playerTransform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HeartProjectile")
        {
            good = true;
            transform.eulerAngles = new Vector3(0, 0, 0);
            Destroy(collision.gameObject);
            GetComponent<SpriteRenderer>().sprite = goodSprite;
            GetComponent<BoxCollider2D>().enabled = false;
            Camera.main.GetComponent<BatAndMouseTracking>().ChangeMouseCounter();
            Camera.main.GetComponent<BatAndMouseTracking>().ActivateText();
        }
    }
}
