using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    bool hasTriggered = false;
    public Player player;
    Vector2 playerPos;
    public TextMeshProUGUI gemText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if the player is near, gravitate to them and apply pickup effect
        if(hasTriggered == true){
            playerPos = player.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, playerPos, (float) .01);
            if(Vector2.Distance(transform.position, playerPos) <= 0.5){
                Destroy(gameObject);
                if(gameObject.CompareTag("Gem")){
                    player.playerGems += 1;
                    gemText.SetText(player.playerGems.ToString());
                }
                else if(gameObject.CompareTag("Health")){
                    player.playerHealthCurrent += 10;
                }
                else if(gameObject.CompareTag("Mana")){
                    player.playerManaCurrent += 5;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player")){
            hasTriggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        hasTriggered = false;
    }

}
