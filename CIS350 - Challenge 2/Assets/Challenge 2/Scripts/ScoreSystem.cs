/*
* Lucas Johnson
* Challenge 2
* Controls the scoring system
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Text textbox;

    public int score = 0;

    public bool gameOver;
    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<Text>();
        textbox.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        textbox.text = "Score: " + score;

        if (score >= 5)
        {
            gameOver = true;
            winText.SetActive(true);

            //Press R to restart if game is over
            if (Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
    }
}
