using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNeighbor : MonoBehaviour
{
    public TileBehavior parent;

    public TileBehavior neighbor;

    public int myIndex;
    /*public BoxCollider2D neighbor;*/

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tile"))
        {
            Debug.Log("Tile is present");
            neighbor = collision.GetComponent<TileBehavior>(); 
            parent.neighbors.Add(neighbor);
        }
    }

}
