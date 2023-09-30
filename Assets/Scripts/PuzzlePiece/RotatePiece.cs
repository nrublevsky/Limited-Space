using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePiece : MonoBehaviour
{

    public void RotateWhileDragging(GameObject piece)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            piece.transform.Rotate(0, 0, 90);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            piece.transform.Rotate(0, 0, -90);
        }

    }
}
