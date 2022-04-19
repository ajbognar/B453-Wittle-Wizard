using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    bool hasTriggered = false;
    bool shrinkActive = false;
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
            playerPos = Player.instance.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, playerPos, (float) .01);
            if(Vector2.Distance(transform.position, playerPos) <= 1f){
                shrinkActive = true;
            }
        }

        if(shrinkActive == true){
            Vector3 targetVector = new Vector3(transform.localScale.x - 0.01f, transform.localScale.y - 0.01f, 1);
            transform.localScale = targetVector;
            if(transform.localScale.x <= 0){
                Destroy(gameObject);
                if(gameObject.CompareTag("Gem")){
                    HealthManaManager.instance.playerGems += 1;
                    gemText.SetText(HealthManaManager.instance.playerGems.ToString());
                }
                else if(gameObject.CompareTag("Health")){
                    HealthManaManager.instance.playerHealthCurrent += 10;
                }
                else if(gameObject.CompareTag("Mana")){
                    HealthManaManager.instance.playerManaCurrent += 5;
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
