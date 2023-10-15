using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    public GameObject bullet;
    public float projectileSpeed;


    public float damage;
    public float shootFrequency;
    public float shotProjectileCount;
    public float maxProjectiles;
    public float maxAmmo;
}
