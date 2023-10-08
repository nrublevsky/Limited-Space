using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Draggabletest : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler, IDragHandler, IDropHandler, IPointerClickHandler
{
    public bool isDragging = false;
    public Vector2 offset;
    public Transform object1Transform;
    public Vector2 mousePosition;

    public Color initColor;

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
        
    }
    

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

    public void OnPointerEnter(PointerEventData eventData)
    {

        if (eventData.pointerEnter.GetComponent<Collider2D>().name == draggedPuzzlePiece.name)
        {
            draggedPuzzlePiece.spriteRenderer.color = Color.grey;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter.GetComponent<Collider2D>().name == draggedPuzzlePiece.name)
        {
            draggedPuzzlePiece.spriteRenderer.color = initColor;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        /* if (gameObject.layer == LayerMask.NameToLayer("PuzzlePieces"))
         {*/
        /*            Debug.LogWarning(gameObject.name);
        */
        /*object1Transform.position = new Vector2(mousePosition.x, mousePosition.y);*/
        /*draggedPuzzlePiece.FreeInteractedTiles();
            isDragging = true;*/
        /*}*/
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        /*isDragging = false;

        draggedPuzzlePiece.OccupyInteractedTiles();
        SnapToObject2();*/
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;
        object1Transform.position = new Vector2(mousePosition.x, mousePosition.y);
        SnapToObject2();
    }

    public void OnDrop(PointerEventData eventData)
    {
        isDragging = false;

        draggedPuzzlePiece.OccupyInteractedTiles();
        SnapToObject2();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        /*if (eventData.button.Equals(Input.GetKey(KeyCode.Mouse1)))
        {
            //perform action
            Debug.Log("Here are the piece details: ");
        }*/
    }
}
