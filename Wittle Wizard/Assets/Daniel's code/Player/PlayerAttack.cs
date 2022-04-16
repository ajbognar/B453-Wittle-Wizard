using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject spellAttack1;
    [SerializeField] GameObject spellAttack2;
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))//check for input / left click
        {
            if (transform.localScale.x > 0)//checks for direction we are facing
            {
                GameObject p = Instantiate(spellAttack1, transform.position - (transform.right), transform.rotation);
                Rigidbody2D rb = p.GetComponent<Rigidbody2D>();
                SpellStats stats = p.GetComponent<SpellStats>();
                rb.velocity = -transform.right * stats.speed;
            }
            else if (transform.localScale.x < 0)//checks for direction we are facing
            {
                GameObject p = Instantiate(spellAttack1, transform.position + (transform.right), transform.rotation);
                Rigidbody2D rb = p.GetComponent<Rigidbody2D>();
                SpellStats stats = p.GetComponent<SpellStats>();
                rb.velocity = transform.right * stats.speed;
            }
        }
        if (Input.GetButtonDown("Fire2"))//check for input / right click
        {
            Vector3 posInScreen = Camera.main.WorldToScreenPoint(transform.position);
            Vector2 direction = (Input.mousePosition - posInScreen);
            direction.Normalize();
            if (transform.localScale.x < 0)//checks for direction we are facing
            {
                GameObject p = Instantiate(spellAttack2, transform.position + (transform.right * 0.5f), transform.rotation);
                Rigidbody2D rb = p.GetComponent<Rigidbody2D>();
                SpellStats stats = p.GetComponent<SpellStats>();
                rb.velocity = direction * stats.speed;
            }
            else if (transform.localScale.x > 0)//checks for direction we are facing
            {
                GameObject p = Instantiate(spellAttack2, transform.position - (transform.right * 0.5f), transform.rotation);
                Rigidbody2D rb = p.GetComponent<Rigidbody2D>();
                SpellStats stats = p.GetComponent<SpellStats>();
                rb.velocity = direction * stats.speed;
            }
        }
    }
}
