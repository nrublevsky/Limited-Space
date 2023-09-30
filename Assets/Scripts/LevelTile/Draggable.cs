using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    Vector2 mousePositionOffset;
    public bool isDragging = false;

    private Vector2 GetMouseWorldPosition()
    {

        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        mousePositionOffset= GetMouseWorldPosition();
        isDragging = true;
    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition();
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDragging) { 
        gameObject.transform.position = other.transform.position;
        }
    }
}
