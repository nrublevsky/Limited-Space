using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{

    public void BeAlive(PuzzlePiece piece, PuzzlePieceBehavior behavior)
    {
        Debug.Log("Starting to rot");
        StartCoroutine(LiveThrough(piece, behavior));
    }

    public IEnumerator LiveThrough(PuzzlePiece piece, PuzzlePieceBehavior behavior)
    {
        while (!behavior.rotten)
        {
            yield return new WaitForSecondsRealtime(piece.lifeLengthSec / piece.stages);
            Debug.Log(behavior.gameObject.name + " is getting worse");
            behavior.currentState++;

            if (behavior.currentState == piece.stages)
            {
                Debug.Log(behavior.gameObject.name + " is Rotten Now");
                behavior.rotten = true;
                break;
            }
        }
    }
}
