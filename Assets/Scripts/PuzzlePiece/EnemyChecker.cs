using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public GunBehavior gun;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gun.reachableEnemies.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gun.reachableEnemies.Remove(collision.gameObject);
        }
    }
}
