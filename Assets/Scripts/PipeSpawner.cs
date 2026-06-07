using UnityEngine;
using System.Collections;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] pipesPrefabs;
    [SerializeField] Vector2 pipeSpawnPosition;
    [SerializeField] float pipeSpawnDelay; 
    Coroutine spawnPipe;

    PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    void Update()
    {
        bool isPlayerAlive = playerMovement.GetIsAlive();
        bool isGameStart = playerMovement.GetIsGameStart();

        if (!isPlayerAlive) { return; }
        if (!isGameStart) { return; }

        if (spawnPipe == null)
        {
            spawnPipe = StartCoroutine(SpawnNewPipe());
        }
    }

    IEnumerator SpawnNewPipe()
    {
        int pipeIndex = Random.Range(0, pipesPrefabs.Length);

        GameObject spawnedPipe = Instantiate(pipesPrefabs[pipeIndex], pipeSpawnPosition, Quaternion.identity);
        
        yield return new WaitForSeconds(pipeSpawnDelay);

        spawnPipe = null;
    }
}
