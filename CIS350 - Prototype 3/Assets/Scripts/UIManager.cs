/*
* Lucas Johnson
* Prototype 3
* Handles Game UI
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    private PlayerContoller playerContollerScript;

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        playerContollerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContoller>();

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerContollerScript.gameOver)
        {
            scoreText.text = "Score: " + score;
        }

        if(playerContollerScript.gameOver && !won)
        {
            scoreText.text = "You Lose!" + "\n" + "Press R to Try Again!";
        }

        if(score >= 10)
        {
            playerContollerScript.gameOver = true;

            won = true;

            playerContollerScript.StopRunning();

            scoreText.text = "You Win!" + "\n" + "Press R to Try Again!";
        }

        if(playerContollerScript.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
