using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> puzzlePieceToSpawn;
    public int numberofPuzzlesTOSpawn;
    public bool spawnIsDpme = false;
    public int countdownTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countDownTillNextSpawn());
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
        numberofPuzzlesTOSpawn = Random.Range(1, 5);
        for (int i = 0; i < numberofPuzzlesTOSpawn; i++)
        {
            Vector3 spawnPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f)); 
            Quaternion spawnRotation = Quaternion.Euler(0, 0, Random.Range(0, 360)); 

            int randomIndex = Random.Range(0, puzzlePieceToSpawn.Count);
            GameObject objectToSpawn = puzzlePieceToSpawn[randomIndex];

            Instantiate(objectToSpawn, spawnPosition, spawnRotation);
            spawnIsDpme = true;
          /* countdownTime = 10;*/
            StartCoroutine(countDownTillNextSpawn());
        }
    }
    IEnumerator countDownTillNextSpawn()
    {while(true)
        {
            
            yield return new WaitForSeconds(10);
            

            SpawnOPuzzles();

        }

    }
}


