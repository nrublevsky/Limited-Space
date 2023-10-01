using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggabletest : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 offset;
    private Transform object1Transform;
    /*public List<TileBehavior> interactedTiles;*/
    /*public List< GameObject> object2 = new List<GameObject>();*/
    public PuzzlePieceBehavior parentPiece;

    void Start()
    {
        object1Transform = transform;
    }


    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            /*   object1Transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);*/
            object1Transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
            SnapToObject2();
        }
        
    }
    void OnMouseDown()
    {
        offset = /*object1Transform.position -*/ Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
        
    }

    void OnMouseUp()
    {
        isDragging = false;
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
                // Check if the collider belongs to object2
                if (parentPiece.interactedTiles.Contains(collider.gameObject.GetComponent<TileBehavior>()))
                {
                    Vector3 object2Center = collider.bounds.center;
                    object1Transform.position = object2Center;
                    break; // Once snapped, exit the loop
                }
            }
        }

    }

    private Vector2 GetMouseWorldPosition()
    {

        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.transform.position = other.transform.position;
    }
}
