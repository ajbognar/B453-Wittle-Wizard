using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColoring : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer render = GetComponent<SpriteRenderer>();//get the renderer to change the color
        EnemyTakeDamage stats = GetComponent<EnemyTakeDamage>();//gets this script because it is where the color indicator is

        if (stats.enemyColor == 1)//change color based on stats, 1 - red, 2 - green, 3 - blue
        {
            render.color = Color.red;
        }
        else if (stats.enemyColor == 2)
        {
            render.color = Color.green;
        }
        else if (stats.enemyColor == 3)
        {
            render.color = Color.blue;
        }
    }

}
