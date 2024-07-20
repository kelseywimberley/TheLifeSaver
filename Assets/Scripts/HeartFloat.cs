using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartFloat : MonoBehaviour
{
    private float sinValue;
    private float speed;

    void Start()
    {
        sinValue = 0;
        speed = 1.25f;
    }

    void Update()
    {
        sinValue += Time.deltaTime * speed;
        transform.localPosition = new Vector3(0, Mathf.Sin(sinValue) * 0.025f, 0);
    }
}
