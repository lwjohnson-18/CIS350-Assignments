/*
 * Lucas Johnson
 * Prototype 5
 * Controls the overal game management
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    private int score;

    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public bool isGameActive = false;

    public GameObject titleScreen;

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;

        isGameActive = true;
        score = 0;
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
        titleScreen.SetActive(false);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
