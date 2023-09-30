using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePieceBehavior : MonoBehaviour
{

    public PuzzlePiece piece;
    public LifeCycle lifeCycle;

    public int currentState;

    public bool rotten = false;

    // Start is called before the first frame update
    void Start()
    {
        lifeCycle.BeAlive(piece, this.GetComponent<PuzzlePieceBehavior>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
