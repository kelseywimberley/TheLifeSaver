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
        speed = 0.005f;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.position += travelDirection * speed;

        if (Vector3.Distance(transform.position, player.transform.position) > 20.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
