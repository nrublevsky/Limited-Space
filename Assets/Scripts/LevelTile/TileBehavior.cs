using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    public List<CheckNeighbor> checkers;
    public List<TileBehavior> neighbors;
    public TileEffect effect;

    public List<TileEffect> neighborEffects;

    public PuzzlePieceBehavior presentFood;

    /*    public CheckOccupancy checkOccupancy;*/


    public bool affected = false;
    public bool occupied = false;

    public event Action OnOccupancy;
    public event Action OnVacancy;

    void Start()
    {

        BecomeOccupied();
        CollectNeighborEffects();
    }


    void Update()
    {

    }

    public void CollectNeighborEffects()
    {
        foreach (CheckNeighbor probe in checkers)
        {
            if (probe != null)
            {
                if (probe.neighbor.effect != null)
                {
                    neighborEffects.Add(probe.neighbor.effect);
                }
            }
        }
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
