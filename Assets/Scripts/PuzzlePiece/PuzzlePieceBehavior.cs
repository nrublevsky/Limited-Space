using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePieceBehavior : MonoBehaviour
{

    public PuzzlePiece piece;
    public LifeCycle lifeCycle;
    public RotatePiece rotatePiece;
    public NeighborEffect myEffect;
    public NeighborEffect neighborEffect;

    public SpriteRenderer spriteRenderer;

    public List<CheckNeighbor> checkers;
    public List<TileBehavior> interactedTiles;
    public List<PuzzlePieceBehavior> neighborPieces;

    public int currentState;

    public bool canBePlaced = false;
    public bool isPlaced = false;

    public bool rotten = false;

    public event Action IsPlaced;
    public event Action IsDisplaced;

    // Start is called before the first frame update
    void Start()
    {
        lifeCycle.BeAlive(piece, this.GetComponent<PuzzlePieceBehavior>());

        IsPlaced += CollectNeighborPieces;
        IsDisplaced += ClearNeighborPieces;
    }

    private void ClearNeighborPieces()
    {
        if (neighborPieces.Count != 0)
        {
            foreach (var piece in neighborPieces)
            {
                neighborPieces.Remove(piece);
            }
        }
    }

    private void CollectNeighborPieces()
    {
        foreach (var probe in checkers)
        {
            if (probe.neighbor != null)
            {
                if (neighborPieces.Count != 0)
                {
                    if (!neighborPieces.Contains(probe.neighbor))
                    neighborPieces.Add(probe.neighbor);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        CheckCanBePlaced();
        rotatePiece.RotateWhileDragging(this.gameObject);

        /*IsPlaced += CollectNeighborPieces;
        IsDisplaced += ClearNeighborPieces;*/

        /*OccupyInteractedTiles();
        FreeInteractedTiles();*/
    }

    public void CheckCanBePlaced()
    {
        if (interactedTiles.Count == piece.size)
        {
            canBePlaced = true;
        }
        if (interactedTiles.Count != piece.size)
        {
            canBePlaced = false;
        }
    }



    public void OccupyInteractedTiles()
    {
        if (!isPlaced)
        {
            isPlaced = true;
            foreach (var tile in interactedTiles)
            {
                tile.occupied = true;

                tile.OnOccupancy += SelectNeighborEffect;
                SetCurrentPuzzlePiece();
                IsPlaced?.Invoke();
            }

            /*IsPlaced += CollectNeighborPieces;*/
        }


    }

    public void SetCurrentPuzzlePiece()
    {

        foreach (TileBehavior tile in interactedTiles)
        {
            if (tile != null)
            {
                if (tile.presentFood == null)
                {
                    tile.presentFood = this;
                }
            }
        }
    }

    public void FreeInteractedTiles()
    {
        if (isPlaced)
        {
            isPlaced = false;
            foreach (var tile in interactedTiles)
            {
                tile.occupied = false;

                tile.OnVacancy += PauseBeAlive;
                RemoveCurrentPuzzlePiece();

                IsDisplaced?.Invoke();


                /*IsDisplaced += ClearNeighborPieces;*/
            }
        }

    }

    public void RemoveCurrentPuzzlePiece()
    {

        foreach (TileBehavior tile in interactedTiles)
        {
            if (tile != null)
            {
                if (tile.presentFood != null)
                {
                    tile.presentFood = null;
                }
            }
        }
    }

    public void SelectNeighborEffect()
    {

        List<NeighborEffect> neighborEffects = new List<NeighborEffect>();

        foreach (PuzzlePieceBehavior neigbor in neighborPieces)
        {
            neighborEffects.Add(neigbor.myEffect);
        }

        foreach (NeighborEffect effect in neighborEffects)
        {
            Debug.Log(effect.name);
            if (myEffect.NegativeCombination.Contains(effect))
            {
                neighborEffect = effect;
                break;
            }
            /*if (!myTileEffect.NegativeCombination.Contains(tile))
            {
                neighborTileEffect = null;
            }*/

        }
    }

    public void PauseBeAlive()
    {
        lifeCycle.PauseBeAlive();
    }

}
