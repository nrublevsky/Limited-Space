using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    public List<CheckNeighbor> checkers;
    public List<TileBehavior> neighbors;
    public NeighborEffect effect;

    public List<NeighborEffect> neighborEffects;

    public PuzzlePieceBehavior presentFood;

    public CheckOccupancy checkOccupancy;


    public bool affected = false;
    public bool occupied = false;

    public event Action OnOccupancy;
    public event Action OnVacancy;

    void Start()
    {

        BecomeOccupied();
        
    }


    void Update()
    {

    }

    

    public void BecomeOccupied()
    {
        if (occupied)
        {
            OnOccupancy?.Invoke();
        }
        if (!occupied)
        {
            OnVacancy?.Invoke();
        }
        if (affected)
        {

        }
    }

}
