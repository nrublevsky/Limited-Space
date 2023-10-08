using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNeighbor : MonoBehaviour
{
    public PuzzlePieceBehavior parent;

    public List<PuzzlePieceBehavior> neighbors;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PuzzlePiece"))
        {
            if (collision.gameObject != this.gameObject)
            {
                Debug.Log(collision.GetComponentInParent<PuzzlePieceBehavior>().piece + " is present");
                neighbors.Add(collision.GetComponentInParent<PuzzlePieceBehavior>());

                parent.neighborPiecesList.Add(collision.GetComponentInParent<PuzzlePieceBehavior>());
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PuzzlePiece"))
        {
            Debug.Log(collision.gameObject.name + " is present");
            neighbors.Remove(collision.GetComponentInParent<PuzzlePieceBehavior>());
            parent.neighborPiecesList.Remove(collision.GetComponentInParent<PuzzlePieceBehavior>());
            /*neighbors = null;*/
        }
    }



}
