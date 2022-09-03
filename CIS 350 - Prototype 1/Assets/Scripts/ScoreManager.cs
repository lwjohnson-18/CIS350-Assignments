/*
* Lucas Johnson
* Prototype 1
* Controls the score
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static bool gameover;
    public static bool won;
    public static int score;

    public Text textbox;

    private void Start()
    {
        gameover = false;
        won = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameover)
        {
            textbox.text = "Score: " + score;
        }

        if(score >= 3)
        {
            won = true;
            gameover = true;
        }

        if (gameover)
        {
            if(won)
            {
                textbox.text = "You win!\nPress R to Try Again!";
            }
            else
            {
                textbox.text = "You lose!\nPress R to Try Again!";
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
