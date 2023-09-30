using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    public bool isAlive = false;


    public void BeAlive(PuzzlePiece piece, PuzzlePieceBehavior behavior)
    {
        Debug.Log("Starting to rot");
        isAlive = true;
        StartCoroutine(LiveThrough(piece, behavior));
    }

    public void PauseBeAlive()
    {
        if (isAlive)
        {
            isAlive = false;
        }
    }

    public IEnumerator LiveThrough(PuzzlePiece piece, PuzzlePieceBehavior behavior)
    {
        while (!behavior.rotten)
        {
            if (isAlive)
            {
                if (behavior.neighborTileEffect == null)
                {
                    yield return new WaitForSecondsRealtime(piece.lifeLengthSec / piece.stages);
                }
                if (behavior.neighborTileEffect != null)
                {
                    yield return new WaitForSecondsRealtime((piece.lifeLengthSec * behavior.neighborTileEffect.neighborTimerDecreaser) / piece.stages);
                }
                Debug.Log(behavior.gameObject.name + " is getting worse");
                behavior.currentState++;
            }
            if (!isAlive)
            {
                yield return null;
            }


            if (behavior.currentState == piece.stages)
            {
                Debug.Log(behavior.gameObject.name + " is Rotten Now");
                behavior.rotten = true;
                break;
            }
        }
    }
}
