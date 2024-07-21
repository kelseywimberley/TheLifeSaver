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
            GetComponent<AudioSource>().Play();
            heart.SetActive(true);
            transform.position = new Vector3(100, 0, 0);
        }
    }
}
