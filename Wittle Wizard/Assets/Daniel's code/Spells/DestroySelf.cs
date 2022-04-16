using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] float travelTime;
    float timer = 0;
    void Update()
    {
        FlyTime();
    }
    void FlyTime()
    {
        timer += Time.deltaTime;
        if (timer >= travelTime)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }

}
