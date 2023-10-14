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
    public List<GameObject> targetsInReach;

    [Header("Static Lists")]
    public List<Weapon> weapons;

    [Header("States")]
    public bool shooting;

    [Header("Changable Objects")]
    public GameObject closestTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SelectClosestEnemy();
    }

    public void SelectClosestEnemy()
    {
        targetsInReach = enemyChecker.targets;

        //If there is Less then 1 target - do nothing
        if (targetsInReach.Count < 1)
        {
            //leaving empty for now
        }
        
        //If there is only 1 target
        if (targetsInReach.Count == 1)
        {
            closestTarget = targetsInReach[0];
        }
        
        //If there is more than 1 target
        if (targetsInReach.Count > 1)
        {
            float closestEnemyPosition = 0;

            //Check distance to each of the targets
            foreach (GameObject enemy in targetsInReach)
            {
                float distanceToTarget = Vector2.Distance(transform.position, enemy.transform.position);


                Debug.Log("Distance to " + enemy.name + " is " + distanceToTarget);

                //If distance to closest enemy is not 0 (every cycle after the first one )
                if (Mathf.Abs(closestEnemyPosition) != 0)
                {
                    //if distance to this enemy is less than distance to currently closest enemy
                    if (Mathf.Abs(closestEnemyPosition) > Mathf.Abs(distanceToTarget))
                    {
                        closestEnemyPosition = distanceToTarget;
                        closestTarget = enemy;
                    }

                    //if distance to this enemy is bigger that distance to currently closest enemy
                    if (Mathf.Abs(closestEnemyPosition) < Mathf.Abs(distanceToTarget))
                    {
                        //leaving empty for now
                    }
                }
                //In case if closest enemy distance is 0 (first object in the list under for-each cycle)
                if (closestEnemyPosition == 0)
                {
                    closestEnemyPosition = distanceToTarget;
                    closestTarget = enemy;
                }
            }
        }
    }


}
