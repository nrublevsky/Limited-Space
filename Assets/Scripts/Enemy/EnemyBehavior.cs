using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public ApproachTarget approach;

    public Rigidbody2D rb;

    public GameObject target;
    public float movSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        approach.MoveToTarget();
    }
}
