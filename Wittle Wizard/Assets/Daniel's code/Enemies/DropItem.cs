using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] GameObject dropHealth;
    [SerializeField] GameObject dropMana;
    [SerializeField] GameObject dropGem;
    EnemyTakeDamage stats;
    void Start()
    {
        stats = GetComponent<EnemyTakeDamage>();//gets the damage script attached to itself so it can know it's health
    }

    void Update()
    {
        if (stats.health < 1)//when the heatlh drops to 0
        {
            int rand = Random.Range(0, 15);//randomly choose one of 3 items to drop **Note: needs to drop spells still, also might rework this system
            if (rand <= 5)
            {
                Instantiate(dropHealth, gameObject.transform.position, Quaternion.identity);
            }
            else if (rand > 5 && rand <= 10)
            {
                Instantiate(dropMana, gameObject.transform.position, Quaternion.identity);
            }
            else if (rand > 10 && rand <= 15)
            {
                Instantiate(dropGem, gameObject.transform.position, Quaternion.identity);
            }
        }
    }
}
