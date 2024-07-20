using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    public GameObject heartProjectilePrefab;
    private Rigidbody2D rb;
    private float timer;

    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        timer = 2.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        if (Vector3.Distance(mouseWorldPos, transform.parent.position) < 0.8f)
        {
            transform.position = mouseWorldPos;
        }
        else
        {
            Vector3 direction = mouseWorldPos - transform.parent.position;
            transform.localPosition = direction.normalized * 0.8f;

            if (Input.GetMouseButtonDown(0) && timer > 2.0f)
            {
                Fire();
            }
        }
    }

    void Fire()
    {
        Vector3 travelDirection = transform.position - transform.parent.position;
        heartProjectilePrefab.GetComponent<TravelingHeart>().travelDirection = travelDirection.normalized;
        Instantiate(heartProjectilePrefab, transform.position, Quaternion.identity);
        timer = 0.0f;
        rb.velocity = travelDirection * -2.5f;
    }
}
