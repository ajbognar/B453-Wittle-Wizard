using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //basic movement related:
    float timer = 0;
    float waitTime = 1;
    float speed = 5f;
    int direction = 1;
    //attack related:
    GameObject player;
    public float range = 5;
    public float attackSpeed = 0.07f;
    float attackTimer = 0;
    Vector3 attackPosition;

    void Awake()
    {
        player = GameObject.Find("wizard-big copy");//finds the character in the scene to calculate distance
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Vector2.Distance(transform.position, player.transform.position) >= range)//player NOT in range
        {
            BasicMovement();//not aggroed
            attackTimer = 0;
        }
        else if (Vector2.Distance(transform.position, player.transform.position) <= range)//player in range
        {
            AttackMovement();//aggroed
        }
    }

    void BasicMovement()
    {
        // float waitTime = Random.Range(1.5, 2.5);
        if (timer <= waitTime)//period of time where nothing happens
        {
            //do nothing
        }
        else if (timer >= waitTime && timer < waitTime + 1)
        {
            if (direction > 0)//decides left or right
            {
                transform.position += new Vector3(Time.deltaTime * speed, 0);
            }
            if (direction < 0)//decides left or right
            {
                transform.position -= new Vector3(Time.deltaTime * speed, 0);
            }
        }
        else if (timer > 4.5)
        {
            timer = 0;
            waitTime = Random.Range(0, 1.5f);
            direction *= -1; //switch directions every time
        }
    }
    void AttackMovement()
    {
        attackTimer += Time.deltaTime;

        if (player.transform.position.x > transform.position.x)//if the player is in range
        {
            attackPosition = new Vector3(player.transform.position.x - 1.5f, player.transform.position.y + 0.5f, player.transform.position.z);//move to hover position
        }
        else if (player.transform.position.x < transform.position.x)
        {
            attackPosition = new Vector3(player.transform.position.x + 1.5f, player.transform.position.y + 0.5f, player.transform.position.z);
        }
        transform.position = Vector3.MoveTowards(transform.position, attackPosition, attackSpeed);//move towards slowly  (follow the player)

        if (attackTimer > 2)
        {

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, attackSpeed * 3);//move in quickly for attack
            attackPosition.x *= -1;
        }
        if (attackTimer > 2.3)
        {
            attackTimer = 0;
        }
    }

}
