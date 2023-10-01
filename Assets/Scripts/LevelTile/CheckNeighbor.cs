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
            /*Debug.Log("Tile is present");*/
            neighbor = collision.GetComponent<PuzzlePieceBehavior>(); 
            parent.neighborPieces.Add(neighbor);
        }
    }

}
