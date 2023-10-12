using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePiece : MonoBehaviour
{
    public PuzzlePieceBehavior puzzlePiece;

    public void RotateToEnemy(GameObject target)
    {
            transform.LookAt(target.transform);
    }
}
