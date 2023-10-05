using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NeighborEffect : ScriptableObject
{
    public string EffectName;

    public float neighborTimerAdder;
    public float neighborTimerDecreaser;

    public bool magic;


    public List<NeighborEffect> PositiveCombination;
    public List<NeighborEffect> NegativeCombination;
    public List<NeighborEffect> SpecialGood;
    public List<NeighborEffect> SpecialBad;

}
