/*
* Lucas Johnson
* Challenge 2
* Detects object collisions
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    private ScoreSystem scoreSystem;

    private void Start()
    {
        scoreSystem = GameObject.Find("Score Text").GetComponent<ScoreSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dog")
        {
            scoreSystem.score++;
            Destroy(gameObject);
        }
    }
}
