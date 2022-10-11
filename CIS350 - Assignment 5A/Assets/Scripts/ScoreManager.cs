/*
* Lucas Johnson
* Prototpe 5A
* Manages UI
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    private PlayerPlatformerController playerContollerScript;

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        playerContollerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPlatformerController>();

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerContollerScript.gameOver)
        {
            scoreText.text = "Score: " + score;
        }

        if (playerContollerScript.gameOver && !playerContollerScript.won)
        {
            scoreText.text = "You Lose!" + "\n" + "Press R to Try Again!";
        }

        if (playerContollerScript.gameOver && playerContollerScript.won)
        {
            playerContollerScript.gameOver = true;

            won = true;

            scoreText.text = "You Win!" + "\n" + "Press R to Try Again!";
        }

        if (playerContollerScript.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
