using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachTarget : MonoBehaviour
{

    

    public EnemyBehavior myBehavior;

    public void MoveToTarget()
    {
        myBehavior.rb.velocity = myBehavior.movSpeed * Time.deltaTime * (myBehavior.target.transform.position - this.gameObject.transform.position);

    }
}
