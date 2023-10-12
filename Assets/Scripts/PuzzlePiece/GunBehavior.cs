using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    [Header("Actions")]
    public RotatePiece rotatePiece;
    public Shoot shoot;

    [Header("Parts")]
    public EnemyChecker enemyChecker;

    [Header("Dynamic Lists")]
    public List<GameObject> reachableEnemies;

    [Header("Static Lists")]
    public List<Weapon> weapons;

    [Header("States")]
    public bool shooting;

    [Header("Changable Objects")]
    public GameObject closestEnemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectClosestEnemy()
    {
        if (reachableEnemies.Count == 1)
        {
            closestEnemy = reachableEnemies[0];
        }
        if (reachableEnemies.Count > 1)
        {
            Vector2 closestEnemyPosition = Vector2.zero;

            foreach (GameObject enemy in reachableEnemies)
            {
                Vector2 enemyPosition = enemy.transform.position;

                if (closestEnemyPosition != Vector2.zero)
                {
                    if (closestEnemyPosition.sqrMagnitude < enemyPosition.sqrMagnitude)
                    {
                        closestEnemyPosition = enemyPosition.normalized;
                        closestEnemy = enemy;
                    }
                    if (closestEnemyPosition.sqrMagnitude > enemyPosition.sqrMagnitude)
                    {
                        //leaving empty for now
                    }
                }
                if (closestEnemyPosition == Vector2.zero)
                {
                    closestEnemyPosition = enemyPosition.normalized;
                    closestEnemy = enemy;
                }
            }
        }
    }


}
