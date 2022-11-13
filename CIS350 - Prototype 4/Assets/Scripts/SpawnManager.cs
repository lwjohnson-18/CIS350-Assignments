/*
* Lucas Johnson
* Prototype 4
* Spawn Manager
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public static bool gameOver = false;

    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public Text waveText;
    public Text gameOverText;
    public int enemyCount;
    public int waveNumber = 1;
    public bool win = false;

    private float spawnRange = 9f;

    private bool tutorial = true;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameOverText.text = "Win: Knock enemies of the platforms and beat wave 10\nLose: Fall off the platform\nPress Spacebar to Start!";
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerup(int powerupsToSpawn)
    {
        for (int i = 0; i < powerupsToSpawn; i++)
        {
            Instantiate(powerupPrefab, GenerateSpawnPos(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    private void Update()
    {
        if(tutorial)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                tutorial = false;
                gameOverText.gameObject.SetActive(false);
                SpawnEnemyWave(waveNumber);
                waveText.text = "Wave: " + waveNumber;
            }

            return;
        }

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount <= 0 && !gameOver)
        {
            if (waveNumber >= 10)
            {
                gameOver = true;
                win = true;
            }

            waveNumber++;
            waveText.text = "Wave: " + waveNumber;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup(1);
        }
        else if(gameOver)
        {
            DisplayGameOverText();

            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void DisplayGameOverText()
    {
        if(win)
        {
            gameOverText.text = "You Win!\nPress R to Restart";
        }
        else
        {
            gameOverText.text = "You Lose!\nPress R to Restart";
        }

        gameOverText.gameObject.SetActive(true);
    }
}
