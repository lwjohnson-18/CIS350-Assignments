using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManagerX : MonoBehaviour
{
    public bool gameOver = false;

    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    public Text waveText;
    public Text gameOverText;
    public GameObject tutorialText;

    private float spawnRangeX = 10;
    private float spawnZMin = 15; // set min spawn Z
    private float spawnZMax = 25; // set max spawn Z

    public int enemyCount;
    public int waveCount = 1;

    public GameObject player;

    private float enemySpeedIncreaseAmount = 0f;
    public int numEnemiesReachedGoal = 0;

    bool tutorial = true;

    // Update is called once per frame
    void Update()
    {
        if(tutorial)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                tutorial = false;
                tutorialText.SetActive(false);
            }

            return;
        }

        if (waveCount != 1 && numEnemiesReachedGoal >= waveCount-1)
        {
            gameOver = true;
            gameOverText.text = "You Lose!\nPress R to Restart!";
            gameOverText.gameObject.SetActive(true);
        }

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0 && !gameOver)
        {
            waveText.text = "Wave: " + waveCount;
            SpawnEnemyWave(waveCount);
        }


        if(gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Generate random spawn position for powerups and enemy balls
    Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }


    void SpawnEnemyWave(int enemiesToSpawn)
    {
        if(waveCount >= 10)
        {
            gameOver = true;
            gameOverText.text = "You Win!\nPress R to Restart!";
            gameOverText.gameObject.SetActive(true);
        }

        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end

        // If no powerups remain, spawn a powerup
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // check that there are zero powerups
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        }

        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            enemy.GetComponent<EnemyX>().speed += enemySpeedIncreaseAmount;
        }

        enemySpeedIncreaseAmount += 2f;
        numEnemiesReachedGoal = 0;
        waveCount++;
        ResetPlayerPosition(); // put player back at start

    }

    // Move player back to position in front of own goal
    void ResetPlayerPosition ()
    {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

}
