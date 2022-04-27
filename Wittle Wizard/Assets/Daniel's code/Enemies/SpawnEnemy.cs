using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    void Start()
    {
        GameObject e = Instantiate(enemy, transform.position, Quaternion.identity);//spawn enemy
        EnemyTakeDamage stats = e.GetComponent<EnemyTakeDamage>();
        stats.enemyColor = Random.Range(1, 3);//generate random color between 1 and 3 inclusive
    }


}
