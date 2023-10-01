using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTiles1 : MonoBehaviour
{
    public TileBehavior currentTile;
    public PuzzlePieceBehavior piece;

   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            currentTile = collision.gameObject.GetComponent<TileBehavior>();
            if (!piece.interactedTiles.Contains(currentTile))
            {
                piece.interactedTiles.Add(currentTile);
            }
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tile"))
        {
            currentTile = collision.GetComponent<TileBehavior>();
            if (!piece.interactedTiles.Contains(currentTile))
            {
                piece.interactedTiles.Add(currentTile);
            }
        }
    }

    /*private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            currentTile = collision.gameObject.GetComponent<TileBehavior>();
        }
    }*/
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tile"))
        {
            currentTile = collision.GetComponent<TileBehavior>();
            if (piece.interactedTiles.Contains(currentTile))
            {
                piece.interactedTiles.Remove(currentTile);
            }
            currentTile = null;
        }
    }
    /*private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            currentTile = collision.gameObject.GetComponent<TileBehavior>();
            if (piece.interactedTiles.Contains(currentTile))
            {
                piece.interactedTiles.Remove(currentTile);
            }
            currentTile = null;
        }
    }*/

}
