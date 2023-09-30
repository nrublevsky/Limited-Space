using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePieceBehavior : MonoBehaviour
{

    public PuzzlePiece piece;
    public LifeCycle lifeCycle;
    public RotatePiece rotatePiece;
    public TileEffect myTileEffect;
    public TileEffect neighborTileEffect;

    public SpriteRenderer spriteRenderer;

    public List<TileBehavior> interactedTiles;

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
                tile.OnOccupancy += SelectNeighborTileEffect;
                tile.CollectNeighborEffects();
                tile.occupied = true;
                tile.effect = myTileEffect;
            }

        }
    }
    public void FreeInteractedTiles()
    {
        if (Input.GetKeyDown(KeyCode.V))// here a condition of ___ and this happens when piece is removed and it stops affecting neighbors of interactedTiles
        {
            foreach (var tile in interactedTiles)
            {
                tile.OnVacancy += PauseBeAlive;
                tile.effect = null;
                tile.occupied = false;
            }
            neighborTileEffect = null;
        }
    }

    public void SelectNeighborTileEffect()
    {
        List<TileEffect> tileEffects = new List<TileEffect>();

        foreach (TileBehavior tile in interactedTiles)
        {
            tileEffects.Add(tile.effect);
        }

        foreach (TileEffect tile in tileEffects)
        {
            Debug.Log(myTileEffect.NegativeCombination.ToString() + "n/" + " looking for " + tile);
            if (myTileEffect.NegativeCombination.Contains(tile))
            {
                neighborTileEffect = tile;
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
