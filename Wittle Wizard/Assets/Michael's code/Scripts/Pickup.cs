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
            transform.position = Vector3.MoveTowards(transform.position, playerPos, .01f);
            if(Vector2.Distance(transform.position, playerPos) <= 1f){
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
            foreach(Collider2D col in GetComponents<Collider2D>()) {
                col.enabled = false;
            }
            GetComponent<Rigidbody2D>().gravityScale = 0;

        }
    }

}
