using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public static GameEnd instance;
    public Image endImage;
    Color imageColor;
    float endTimer = 0f;
    bool hasEnded = false;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        endImage.gameObject.SetActive(true);
        imageColor = endImage.color;
        imageColor.a = 0f;
        endImage.color = imageColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasEnded){
            endTimer += Time.deltaTime;
            imageColor.a = endTimer/1;
            endImage.color = imageColor;
            if(endTimer > 2){
                Application.Quit();
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }

    public void TriggerEnd()
    {
        hasEnded = true;
    }
}