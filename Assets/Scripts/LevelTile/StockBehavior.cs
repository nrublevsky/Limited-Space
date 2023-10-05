using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockBehavior : MonoBehaviour
{

    public GameManager1 manager;

    public List<TileBehavior> stockTiles;

    public PuzzlePieceBehavior[] presentPieces;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        presentPieces = GetComponentsInChildren<PuzzlePieceBehavior>();

    }
}
