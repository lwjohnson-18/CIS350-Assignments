/*
* Lucas Johnson
* Prototype 3
* Spawns Objects repeatedly
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);

    private float startDelay = 2f;
    private float repeatRate = 2f;

    private PlayerContoller playerContollerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerContollerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();


        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        if (playerContollerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
