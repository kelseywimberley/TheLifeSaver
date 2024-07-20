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
        timer = 0;
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (!good)
        {
            if (Vector3.Distance(playerTransform.position, transform.position) < 5.0f)
            {
                timer += Time.deltaTime;

                if (timer > 3.0f)
                {
                    Vector3 travelDirection = playerTransform.position - transform.position;
                    attackPrefab.GetComponent<TravelingHeart>().travelDirection = travelDirection.normalized;
                    Instantiate(attackPrefab, transform.position, Quaternion.identity);
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
            Destroy(collision.gameObject);
            anim.SetBool("isGood", true);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
