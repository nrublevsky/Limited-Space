using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggabletest : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 offset;

    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
        SnapToGrid();
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = GetMouseWorldPosition();
        }
    }
    void SnapToGrid()
    {
        
        float snapX = Mathf.Round(transform.position.x);
        float snapY = Mathf.Round(transform.position.y);

        
        transform.position = new Vector2(snapX, snapY);

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
