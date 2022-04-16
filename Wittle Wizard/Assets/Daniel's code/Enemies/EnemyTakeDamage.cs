using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    public float health = 10;
    public float enemyColor = 1; //1 - red, 2 - green, 3 - blue
    [SerializeField] GameObject particlesBlue;
    [SerializeField] GameObject particlesRed;
    [SerializeField] GameObject particlesGreen;
    [SerializeField] GameObject damageGreen;
    [SerializeField] GameObject damageBlue;
    [SerializeField] GameObject damageRed;
    private void Update()
    {
        if (health <= 0)//handles death effect
        {
            if (enemyColor == 1)
            {
                Instantiate(particlesRed, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (enemyColor == 2)
            {
                Instantiate(particlesGreen, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (enemyColor == 3)
            {
                Instantiate(particlesBlue, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Spell")
        {
            SpellStats stats = other.GetComponent<SpellStats>();
            if (stats.spellColor == 1 && health > 0)//handles damage effect on the enemy
            {
                Instantiate(damageRed, gameObject.transform.position, Quaternion.identity);
            }
            else if (stats.spellColor == 2 && health > 0)
            {
                Instantiate(damageGreen, gameObject.transform.position, Quaternion.identity);
            }
            else if (stats.spellColor == 3 && health > 0)
            {
                Instantiate(damageBlue, gameObject.transform.position, Quaternion.identity);
            }
            if (stats.spellColor == enemyColor)//take half damage if the spell color matches the enemy color
            {
                health -= (stats.damage * 0.5f);
            }
            else//take full damage if the colors mismatch
            {
                health -= stats.damage;
            }
            Destroy(other.gameObject);
        }
    }

}
