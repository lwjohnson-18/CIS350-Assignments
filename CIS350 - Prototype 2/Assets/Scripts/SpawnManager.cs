/*
* Lucas Johnson
* Prototype 2
* Controls the spawning of animals
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public HealthSystem healthSystem;
    public GameObject[] prefabsToSpawn;
    public bool gameOver = false;

    private float leftBound = -14;
    private float rightBound = 14;
    private float spawnPosZ = 20;

    private void Start()
    {
        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();

        StartCoroutine(SpawnRandomPrefabWithCoroutine());
    }

    IEnumerator SpawnRandomPrefabWithCoroutine()
    {
        yield return new WaitForSeconds(3f);

        while(!healthSystem.gameOver)
        {
            SpawnRandomPrefab();

            float randomDelay = Random.Range(1.5f, 3.0f);

            yield return new WaitForSeconds(randomDelay);
        }
    }

    void SpawnRandomPrefab()
    {
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

        Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, spawnPosZ);

        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
    }
}
