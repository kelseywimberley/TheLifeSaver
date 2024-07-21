using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHeart : MonoBehaviour
{
    public GameObject heart;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            heart.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
