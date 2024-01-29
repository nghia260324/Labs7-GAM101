using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public string effectHitEnemy;
    [HideInInspector]
    public string effectHitChest;

      
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            collision.gameObject.GetComponent<EnemyController>().TakeDamage();
            Destroy(gameObject);
        }
        if (collision.CompareTag("Chest"))
        {
            collision.gameObject.GetComponent<ChestManager>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
