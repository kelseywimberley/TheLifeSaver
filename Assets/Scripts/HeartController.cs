using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    public GameObject heartProjectilePrefab;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        if (Vector3.Distance(mouseWorldPos, transform.parent.position) < 0.8f)
        {
            transform.position = mouseWorldPos;
        }
        else
        {
            Vector3 direction = mouseWorldPos - transform.parent.position;
            transform.position = direction.normalized * 0.8f;

            if (Input.GetMouseButtonDown(0))
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
    }
}
