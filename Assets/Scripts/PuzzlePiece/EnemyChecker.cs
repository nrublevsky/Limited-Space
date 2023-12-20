using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public GunBehavior gun;
    public List<GameObject> targets;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            /*Debug.Log(collision.gameObject.name + " is noticed");*/
            targets.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            /*Debug.Log(collision.gameObject.name + " is noticed");*/
            targets.Remove(collision.gameObject);
        }
    }
}