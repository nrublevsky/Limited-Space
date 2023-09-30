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
            transform.position = new Vector2(mousePosition.x + offset.x, mousePosition.y + offset.y);
        }
    }
    void SnapToGrid()
    {
        // Calculate the position on the grid
        float snapX = Mathf.Round(transform.position.x);
        float snapY = Mathf.Round(transform.position.y);

        // Set the position to the snapped position
        transform.position = new Vector2(snapX, snapY);
    }
}
