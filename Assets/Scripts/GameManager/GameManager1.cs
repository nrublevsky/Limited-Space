using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public List<GameObject> puzzlePieceToSpawn;
    public List<Vector3> puzzleSpawnPosition;
    public List<GameObject> puzzlesInScene;

    public List<PuzzlePieceBehavior> puzzlesSpawned;

    public StockBehavior stock;

    public int numberofPuzzlesTOSpawn;
    public bool spawnIsDpme = false;
    public int countdownTime = 10;
    public int spawnFrq;
    public int stockSize;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownTillNextSpawn());
        CollectStockPositions();
        /*InvokeRepeating("DestroyRandomObjectsWhichArePlaced", 0f, 10f);*/

    }

    private void CollectStockPositions()
    {
        puzzleSpawnPosition = new List<Vector3>();

        foreach (var piece in stock.stockTiles)
        {
            puzzleSpawnPosition.Add(piece.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!spawnIsDpme)
        {
            SpawnOPuzzles();

        }*/



    }

    void SpawnOPuzzles()
    {

        numberofPuzzlesTOSpawn = 1;

        Vector2 spawnPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));


        int randomIndex = Random.Range(1, puzzlePieceToSpawn.Count);
        int rabdinsoawposition = Random.Range(0, puzzleSpawnPosition.Count);
        GameObject objectToSpawn = puzzlePieceToSpawn[randomIndex];

        Instantiate(objectToSpawn, puzzleSpawnPosition[rabdinsoawposition], transform.rotation, stock.transform);
        objectToSpawn.GetComponent<PuzzlePieceBehavior>().OccupyInteractedTiles();

        puzzlesSpawned.Add(objectToSpawn.GetComponent<PuzzlePieceBehavior>());
        spawnIsDpme = true;

    }
    IEnumerator CountDownTillNextSpawn()
    {
        while (stock.presentPieces.Length != stockSize)
        {

            yield return new WaitForSecondsRealtime(spawnFrq);


            SpawnOPuzzles();

        }

    }
    void DestroyRandomObjectsWhichArePlaced()
    {
        GameObject[] objectsWhichPlaced = GameObject.FindGameObjectsWithTag("PuzzlePiece");
        List<GameObject> puzzlePiecesToDestroy = new List<GameObject>();
        foreach (GameObject obj in objectsWhichPlaced)
        {

            PuzzlePieceBehavior puzzlePieceBehavior = obj.GetComponent<PuzzlePieceBehavior>();
            if (puzzlePieceBehavior != null && puzzlePieceBehavior.isPlaced)
            {
                puzzlePiecesToDestroy.Add(obj);
            }
            if (puzzlePiecesToDestroy.Count > 0)
            {
                int randomIndex = Random.Range(0, puzzlePiecesToDestroy.Count);
                Destroy(puzzlePiecesToDestroy[randomIndex]);
            }
        }
    }
}


