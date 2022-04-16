using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    public float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            Destroy(gameObject);
        }
    }
}
