using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PuzzlePiece : ScriptableObject
{
    public string pieceName;

    public int size;
    public int stages;
    

    public float lifeLengthSec;
    

/*    public float[] multipliers; */
    
    public Renderer renderer;

}
