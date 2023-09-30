using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePieceBehavior : MonoBehaviour
{

    public PuzzlePiece piece;
    public LifeCycle lifeCycle;
    public RotatePiece rotatePiece;

    public List<TileBehavior> interactedTiles;

    public int currentState;

    public bool canBePlaced = false;

    public bool rotten = false;

    // Start is called before the first frame update
    void Start()
    {
        lifeCycle.BeAlive(piece, this.GetComponent<PuzzlePieceBehavior>());
    }

    // Update is called once per frame
    void Update()
    {
        CheckCanBePlaced();
        rotatePiece.RotateWhileDragging(this.gameObject);
    }

    public void CheckCanBePlaced()
    {
        if (interactedTiles.Count == piece.size)
        {
            canBePlaced = true;
        }
        if (interactedTiles.Count != piece.size)
        {
            canBePlaced = false;
        }
    }

}
