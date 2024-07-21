using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BatBehavior : MonoBehaviour
{
    private bool good;
    private Animator anim;
    public GameObject attackPrefab;
    private float timer;
    private Transform playerTransform;

    void Start()
    {
        good = false;
        anim = GetComponent<Animator>();
        timer = 1.5f;
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
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

        if (!good)
        {
            // Attack
            if (Vector3.Distance(playerTransform.position, transform.position) < 5.0f)
            {
                timer += Time.deltaTime;

                if (timer > 3.0f)
                {
                    Vector3 travelDirection = playerTransform.position - transform.position;
                    attackPrefab.GetComponent<TravelingHeart>().travelDirection = travelDirection.normalized;
                    GameObject attack = Instantiate(attackPrefab, transform.position, Quaternion.identity);
                    attack.GetComponent<AudioSource>().Play();
                    timer = 0.0f;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HeartProjectile")
        {
            good = true;
            GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            anim.SetBool("isGood", true);
            GetComponent<BoxCollider2D>().enabled = false;
            Camera.main.GetComponent<BatAndMouseTracking>().ChangeBatCounter();
            Camera.main.GetComponent<BatAndMouseTracking>().ActivateText();
        }
    }
}
