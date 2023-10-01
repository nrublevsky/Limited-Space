using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNeighbor : MonoBehaviour
{
    public PuzzlePieceBehavior parent;

    public PuzzlePieceBehavior neighbor;

    public int myIndex;
    /*public BoxCollider2D neighbor;*/

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PuzzlePiece"))
        {
            Debug.Log(collision.GetComponentInParent<PuzzlePieceBehavior>().piece + " is present");
            neighbor = collision.GetComponentInParent<PuzzlePieceBehavior>();
            if (parent.neighborPieces.Count == 0)
            {
                parent.neighborPieces.Add(neighbor);
            }
            if (parent.neighborPieces.Count > 0)
            {

                if (!parent.neighborPieces.Contains(neighbor))
                {
                    parent.neighborPieces.Add(neighbor);
                }

            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PuzzlePiece"))
        {
            Debug.Log(collision.gameObject.name + " is present");
            neighbor = collision.GetComponentInParent<PuzzlePieceBehavior>();
            parent.neighborPieces.Remove(neighbor);
            neighbor = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PuzzlePiece"))
        {
            Debug.Log("Neighbor is Present");
            neighbor = collision.gameObject.GetComponent<PuzzlePieceBehavior>();
            parent.neighborPieces.Add(neighbor);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PuzzlePiece"))
        {
            Debug.Log("Removing neighbor " + neighbor.name);
            neighbor = null;
            parent.neighborPieces.Remove(neighbor);
        }
    }

}
