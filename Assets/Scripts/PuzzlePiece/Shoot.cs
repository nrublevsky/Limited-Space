using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GunBehavior gunBehavior;
    public GameObject parent;
    public GameObject gunPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShootWeapon()
    {
        StartCoroutine(ProduceProjectile(gunBehavior.currentWeapon.bullet, gunBehavior.currentShootFreq));
        

    }

    public void DeductAmmo(float currentAmmo)
    {
        currentAmmo--;
    }

    public IEnumerator ProduceProjectile(GameObject bullet, float currentShootFreq)
    {
        while (gunBehavior.currentAmmo != 0)
        {
            Instantiate(bullet,gunPoint.transform);
            DeductAmmo(gunBehavior.currentAmmo);
            yield return new WaitForSecondsRealtime(currentShootFreq);
        }
    }

    public void CreateProjectile() { }
}
