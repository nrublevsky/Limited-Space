using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    public bool affected;
    public bool occupied;

    public GameObject presentFood;

    public List<TileBehavior> neighbors;

    public CheckNeighbor[] checkers;

    void Start()
    {
        
       /* FillInNeighborsList();*/
    }


    void Update()
    {

    }

    public void FillInNeighborsList()
    {
        foreach (CheckNeighbor checker in checkers)
        {
            
                neighbors.Add(checker.neighbor);
        }

    }
}
