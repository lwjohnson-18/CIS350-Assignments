/*
* Lucas Johnson
* Challenge 2
* Controls the health system
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Text textbox;

    public int health;
    public int maxHealth = 5;

    public bool gameOver = false;

    public GameObject gameOverText;

    private void Start()
    {
        textbox = GetComponent<Text>();
        textbox.text = "Health: " + maxHealth;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //If health is somehow more than max health, set health to max health
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        textbox.text = "Health: " + health;

        if (health <= 0)
        {
            gameOver = true;
            gameOverText.SetActive(true);

            //Press R to restart if game is over
            if (Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
    }

    public void TakeDamage()
    {
        health--;
    }
}
