using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TileEffect : ScriptableObject
{
    public string EffectName;

    public float neighborTimerAdder;
    public float neighborTimerDecreaser;

    public bool magic;


    public List<TileEffect> PositiveCombination;
    public List<TileEffect> NegativeCombination;
    public List<TileEffect> SpecialGood;
    public List<TileEffect> SpecialBad;

}
