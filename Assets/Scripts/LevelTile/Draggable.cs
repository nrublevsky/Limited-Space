using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    Vector2 mousePositionOffset;

    private Vector2 GetMouseWorldPosition()
    {

        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        mousePositionOffset= GetMouseWorldPosition();
    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        transform.position = other.transform.position;
    }
}
