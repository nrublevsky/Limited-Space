using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Weapon myWeapon;
    public Rigidbody2D myRigidbody;
    public GunBehavior mygunBehavior;
    

    void Start()
    {
        transform.parent = null;
        myRigidbody = this.GetComponent<Rigidbody2D>();
        myRigidbody.velocity = MyTarget().transform.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //add method to move to Enemy's front position
        /*myRigidbody.velocity = myTarget.transform.position - transform.position;*/
    }

    public GameObject MyTarget() {

        return mygunBehavior.closestTarget;
    }
}
