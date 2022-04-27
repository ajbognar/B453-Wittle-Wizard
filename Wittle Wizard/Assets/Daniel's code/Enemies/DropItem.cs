using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] GameObject dropHealth;
    [SerializeField] GameObject dropMana;
    [SerializeField] GameObject dropGem;
    [SerializeField] ItemDropTracker drops;
    private bool dropped;
    EnemyTakeDamage stats;
    void Start()
    {
        stats = GetComponent<EnemyTakeDamage>();//gets the damage script attached to itself so it can know it's health
        dropped = false;
        if (drops.initialized == true)
        {
            //Debug.Log("drops already initalized");
            //do nothing
        }
        else if (drops.initialized == false)
        {
            drops.initialized = true;
            drops.gemTracker = 0;
            drops.healthTracker = 0;
            drops.manaTracker = 0;
            //Debug.Log("Initialised drops!!!");
        }
    }

    void Update()
    {
        if (stats.health < 1)//when the heatlh drops to 0
        {
            int randHealth = Random.Range(drops.healthTracker, 15);//randomly choose one of 3 items to drop **Note: needs to drop spells still, also might rework this system
            int randMana = Random.Range(drops.manaTracker, 15);
            int randGem = Random.Range(drops.gemTracker, 15);
            //if any of the random variables are above 10, spawn the item (only one) and reset it's tracker to 0 (the higher the tracker, the more likely it is to spawn the item)
            if (randHealth > 10 && dropped == false)
            {
                dropped = true;
                Instantiate(dropHealth, gameObject.transform.position, Quaternion.identity);
                drops.healthTracker = 0;
                //iterate other drops to make the next drop more likely to be one of them
                drops.gemTracker++;
                drops.manaTracker++;
            }
            else if (randMana > 10 && dropped == false)
            {
                dropped = true;
                Instantiate(dropMana, gameObject.transform.position, Quaternion.identity);
                drops.manaTracker = 0;
                //iterate other drops to make the next drop more likely to be one of them
                drops.healthTracker++;
                drops.gemTracker++;
            }
            else if (randGem > 10 && dropped == false)
            {
                dropped = true;
                Instantiate(dropGem, gameObject.transform.position, Quaternion.identity);
                drops.gemTracker = 0;
                //iterate other drops to make the next drop more likely to be one of them
                drops.healthTracker++;
                drops.manaTracker++;
            }
            else
            {//if no item is droppped
             //iterate each tracker, making drops more likely
                drops.gemTracker++;
                drops.healthTracker++;
                drops.manaTracker++;
                //check each tracker b/c if it is greater than 15 there will be problems
                if (drops.gemTracker >= 15)
                {
                    drops.gemTracker = 13;
                }
                if (drops.healthTracker >= 15)
                {
                    drops.healthTracker = 13;
                }
                if (drops.manaTracker >= 15)
                {
                    drops.healthTracker = 13;
                }
            }
        }
    }
}
