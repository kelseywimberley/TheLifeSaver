using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelingHeart : MonoBehaviour
{
    public Vector3 travelDirection;
    private float speed;
    private GameObject player;

    void Start()
    {
        speed = 2.5f;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.position += travelDirection * speed * Time.deltaTime;

        if (tag != "HeartProjectile")
        {
            transform.Rotate(0, 0, 0.05f);
        }

        if (Vector3.Distance(transform.position, player.transform.position) > 10.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
