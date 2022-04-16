using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//shake the camera
public class CameraShaker : MonoBehaviour
{
    public static CameraShaker shaker;
    private float shakeTimer = 0f;
    private float xShake, yShake, shakeIntensity;

    // Start is called before the first frame update
    void Start()
    {
        shaker = this;
    }

    void Update()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(shakeTimer > 0){
            shakeTimer -= Time.deltaTime;
            xShake = Random.Range(-.1f, .1f) * shakeIntensity;
            yShake = Random.Range(-.1f, .1f) * shakeIntensity;

            transform.position += new Vector3(xShake, yShake, 0f);
        }
    }

    public void ShakeScreen(float time, float intensity)
    {
        shakeTimer = time;
        shakeIntensity = intensity;
    }
}
