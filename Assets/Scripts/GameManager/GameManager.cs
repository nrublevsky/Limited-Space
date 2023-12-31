using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> puzzlePieceToSpawn;
    public List<Vector2> puzzleSpawnPosition;
    public List<GameObject> puzzlesInScene;
    public int numberofPuzzlesTOSpawn;
    public bool spawnIsDpme = false;
    public int countdownTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countDownTillNextSpawn());
        InvokeRepeating("DestroyRandomObjectsWhichArePlaced", 0f, 10f);
        
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
       /* for (int i = 0; i < numberofPuzzlesTOSpawn; i++)
        {*/
            Vector2 spawnPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f)); 
           /* Quaternion spawnRotation = Quaternion.Euler(0, 0, Random.Range(0, 360)); */

            int randomIndex = Random.Range(0, puzzlePieceToSpawn.Count);
            int rabdinsoawposition = Random.Range(0, puzzleSpawnPosition.Count);
            GameObject objectToSpawn = puzzlePieceToSpawn[randomIndex];

            Instantiate(objectToSpawn, puzzleSpawnPosition[rabdinsoawposition], transform.rotation);
            spawnIsDpme = true;
          /* countdownTime = 10;*/
            /*StartCoroutine(countDownTillNextSpawn());*/
        /*}*/
    }
    IEnumerator countDownTillNextSpawn()
    {while(true)
        {
            
            yield return new WaitForSeconds(10);
            

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
            if(puzzlePieceBehavior != null&& puzzlePieceBehavior.isPlaced)
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


