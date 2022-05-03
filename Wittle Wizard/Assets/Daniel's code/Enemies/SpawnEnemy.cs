using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    float time = 0;
    bool spawned = false;
    void Start()
    {
        /*
        GameObject e = Instantiate(enemy, transform.position, Quaternion.identity);//spawn enemy
        EnemyTakeDamage stats = e.GetComponent<EnemyTakeDamage>();
        stats.enemyColor = Random.Range(1, 4);//generate random color between 1 and 3 inclusive
        */
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.6 && spawned == false)
        {
            GameObject e = Instantiate(enemy, transform.position, Quaternion.identity);//spawn enemy
            EnemyTakeDamage stats = e.GetComponent<EnemyTakeDamage>();
            stats.enemyColor = Random.Range(1, 4);//generate random color between 1 and 3 inclusive
            spawned = true;
        }
    }


}
