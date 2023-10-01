using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOccupancy : MonoBehaviour
{

    public PuzzlePieceBehavior puzzlePiece;
    public TileBehavior tileBehavior;

    public void SetOccupancy()
    {
        if (puzzlePiece != null)
        {
            if (puzzlePiece.gameObject.GetComponent<Draggable>().isDragging)
            {
                tileBehavior.occupied = false;
            }
            tileBehavior.occupied = true;

        }
    }


}
