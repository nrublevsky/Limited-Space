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

    public bool rotten = false;

    // Start is called before the first frame update
    void Start()
    {
        lifeCycle.BeAlive(piece, this.GetComponent<PuzzlePieceBehavior>());
    }

    // Update is called once per frame
    void Update()
    {
        CheckCanBePlaced();
        rotatePiece.RotateWhileDragging(this.gameObject);
        OccupyInteractedTiles();
        FreeInteractedTiles();
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
        if (Input.GetKeyDown(KeyCode.Space))// here a condition of ___ and this happens when piece is placed and it starts affecting neighbors of interactedTiles
        {
            foreach (var tile in interactedTiles)
            {
                tile.occupied = true;

                tile.OnOccupancy += SelectNeighborEffect;
                SetCurrentPuzzlePiece();


            }

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
        if (Input.GetKeyDown(KeyCode.V))// here a condition of ___ and this happens when piece is removed and it stops affecting neighbors of interactedTiles
        {
            foreach (var tile in interactedTiles)
            {
                tile.occupied = false;

                tile.OnVacancy += PauseBeAlive;
                RemoveCurrentPuzzlePiece();

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
