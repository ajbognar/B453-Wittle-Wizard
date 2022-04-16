using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpell : MonoBehaviour
{
    bool playerNear = false;
    public SpriteRenderer spriteRenderer;
    Spell spellPickup;
    public Transform prefab;

    // Start is called before the first frame update
    void Start()
    {
        spellPickup = SpellTracker.spellInstance.GetTrackedSpell();
        spriteRenderer.sprite = spellPickup.icon;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerNear)
        {
            if(Input.GetKeyDown("e"))
            {
                //add a spell to the spell tracker singleton, so the the newly spawned pickup knows what it is
                SpellTracker.spellInstance.SetTrackedSpell(Player.instance.activeSpell);
                //check if it's the starting empty spell (cost = 0), which it shouldn't instantiate
                if(SpellTracker.spellInstance.GetTrackedSpell().cost != 0){
                    Instantiate(prefab, transform.position, Quaternion.identity);
                }
                Player.instance.SetActive(spellPickup);
                Destroy(gameObject);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        playerNear = true;
        SpellTracker.spellInstance.SetTrackedSpell(Player.instance.activeSpell);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        playerNear = false;
    }
}
