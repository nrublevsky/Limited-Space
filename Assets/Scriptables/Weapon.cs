using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    public Sprite projectileSprite;

    public float damage;
    public float attackSpeed;
    public float shotProjectileCount;
    public float maxProjectiles;
}
