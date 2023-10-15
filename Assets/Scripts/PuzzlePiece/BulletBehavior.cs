using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Weapon myWeapon;
    public Rigidbody2D myRigidbody;

    void Start()
    {
        transform.parent = null;
        myRigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.AddForce(Vector2.right * Time.deltaTime * myWeapon.projectileSpeed, ForceMode2D.Force) ;
    }
}
