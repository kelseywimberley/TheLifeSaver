using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private float speed;

    void Start()
    {
        anim = GetComponent<Animator>();
        speed = 0.01f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {

        }

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position - new Vector3(1.0f * speed, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + new Vector3(1.0f * speed, 0, 0);
            transform.localScale = Vector3.one;
            anim.SetBool("isWalking", true);
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.localScale = Vector3.one;
            anim.SetBool("isWalking", false);
        }
    }
}
