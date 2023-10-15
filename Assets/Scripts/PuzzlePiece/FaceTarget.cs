using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTarget: MonoBehaviour
{
    /*public GameObject gun;*/

    public void RotateToEnemy(GameObject target)
    {
        /*transform.LookAt(target.transform.position, Vector3.forward);*/
        
        //________________

        /*Vector3 relativePos = target.transform.position - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
        transform.rotation = rotation;*/

        //_______________

        float angle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 15);

    }
}
