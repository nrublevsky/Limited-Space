using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    [Header("Actions")]
    public FaceTarget faceTarget;
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

    [Header("Variables")]
    public Weapon currentWeapon;
    public float currentAmmo;
    public float currentShootFreq;



    void Start()
    {
        //when created - sets variables based on it's setting
        SetInitialValues();
    }


    void Update()
    {
        SelectClosestEnemy();

        if (closestTarget != null)
        {
            ShootPresentTarget();
        }

        if (currentWeapon == null)
        {
            
        }
    }

    public void SelectClosestEnemy()
    {
        targetsInReach = enemyChecker.targets;

        //If there is Less then 1 target - do nothing
        if (targetsInReach.Count < 1)
        {
            closestTarget = null;
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


                /*Debug.Log("Distance to " + enemy.name + " is " + distanceToTarget);*/

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
                /*faceTarget.RotateToEnemy(closestTarget);*/
            }
            /*faceTarget.RotateToEnemy(closestTarget);*/
        }
        if (targetsInReach.Count != 0)
        {
            faceTarget.RotateToEnemy(closestTarget);
        }
    }

    public void ShootPresentTarget()
    {
        shoot.ShootWeapon();
    }
    public void SetInitialValues()
    {
        currentWeapon = weapons[0];
        currentAmmo = currentWeapon.maxAmmo;
        currentShootFreq = currentWeapon.shootFrequency;
    }


}
