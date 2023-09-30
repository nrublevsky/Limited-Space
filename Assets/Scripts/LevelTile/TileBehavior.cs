using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    public CheckNeighbor[] checkers;
    public List<TileBehavior> neighbors;
    public TileEffect effect;

    public GameObject presentFood;

    public CheckOccupancy checkOccupancy;

    public bool affected = false;
    public bool occupied = false;


    void Start()
    {
        
       
    }


    void Update()
    {

    }

    
}
