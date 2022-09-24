/*
* Lucas Johnson
* Challenge 3
* Manages UI
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    private PlayerControllerX playerContollerScript;

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        playerContollerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerX>();

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerContollerScript.gameOver)
        {
            scoreText.text = "Score: " + score;
        }

        if (playerContollerScript.gameOver && !won)
        {
            scoreText.text = "You Lose!" + "\n" + "Press R to Try Again!";
        }

        if (score >= 30)
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
