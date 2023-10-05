using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Draggabletest : MonoBehaviour
{
    public bool isDragging = false;
    public Vector2 offset;
    public Transform object1Transform;
    public Vector2 mousePosition;

    public Color initColor;
    /*public List<TileBehavior> interactedTiles;*/
    /*public List< GameObject> object2 = new List<GameObject>();*/
    public PuzzlePieceBehavior draggedPuzzlePiece;

    public UnityEvent CheckTileAndNeighbor;

    void Start()
    {
        object1Transform = this.gameObject.transform;
        initColor = draggedPuzzlePiece.spriteRenderer.color;
    }


    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (isDragging)
        {

            /*   object1Transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);*/
            object1Transform.position = new Vector2(mousePosition.x, mousePosition.y);
            SnapToObject2();
        }

    }
    public void OnMouseDown()
    {
        Physics2D.queriesHitTriggers = true;

        Debug.LogWarning(gameObject.GetComponent<Collider2D>().name);

        if (gameObject.layer == LayerMask.NameToLayer("PuzzlePieces"))
        {
            Debug.LogWarning(gameObject.name);

            object1Transform.position = new Vector2(mousePosition.x, mousePosition.y);
            draggedPuzzlePiece.FreeInteractedTiles();
            isDragging = true;
        }


    }

    private void OnMouseOver()
    {
        if (gameObject.layer == LayerMask.NameToLayer("PuzzlePieces"))
        {
            if (draggedPuzzlePiece != null)
            {
                draggedPuzzlePiece.spriteRenderer.color = Color.grey;
            }
        }
    }

    private void OnMouseExit()
    {
        if (gameObject.layer == LayerMask.NameToLayer("PuzzlePieces"))
        {
            if (draggedPuzzlePiece != null)
            {
                draggedPuzzlePiece.spriteRenderer.color = initColor;
            }
        }
    }

    public void OnMouseUp()
    {
        isDragging = false;
        
        draggedPuzzlePiece.OccupyInteractedTiles();
        /*draggedPuzzlePiece.gameObject.transform.position = draggedPuzzlePiece.interactedTiles.ElementAt(1).gameObject.GetComponent<Collider2D>().bounds.center;*/
        SnapToObject2();
    }

    /* void Update()
     {
         if (isDragging)
         {
             Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             transform.position = GetMouseWorldPosition();
         }
     }*/
    void SnapToObject2()
    {

        Collider2D[] colliders = Physics2D.OverlapPointAll(object1Transform.position);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject) // Skip self
            {
                if (collider.CompareTag("Tile"))
                {
                    // Check if the collider belongs to object2
                    if (draggedPuzzlePiece.interactedTiles.Contains(collider.gameObject.GetComponent<TileBehavior>()))
                    {
                        Vector2 object2Center = collider.bounds.center;
                        object1Transform.position = object2Center;
                        break; // Once snapped, exit the loop
                    }
                }
            }
        }

    }

    private Vector2 GetMouseWorldPosition()
    {

        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    /* private void OnTriggerEnter2D(Collider2D other)
     {
         gameObject.transform.position = other.transform.position;
     }*/
}
