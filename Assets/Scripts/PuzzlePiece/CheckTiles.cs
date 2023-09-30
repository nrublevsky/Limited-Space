using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTiles : MonoBehaviour
{
    public TileBehavior currentTile;
    public PuzzlePieceBehavior piece;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            currentTile = collision.gameObject.GetComponent<TileBehavior>();
            piece.interactedTiles.Add(currentTile);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            currentTile = collision.gameObject.GetComponent<TileBehavior>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            currentTile = collision.gameObject.GetComponent<TileBehavior>();
            piece.interactedTiles.Remove(currentTile);
        }
    }

}
