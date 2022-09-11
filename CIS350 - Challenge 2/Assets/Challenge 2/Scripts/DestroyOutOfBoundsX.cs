/*
* Lucas Johnson
* Challenge 2
* Destroys objects when they go out of bounds
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -30;
    private float bottomLimit = -5;

    private HealthSystem healthSystem;
    private void Start()
    {
        healthSystem = GameObject.Find("Health Text").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            healthSystem.TakeDamage();
            Destroy(gameObject);
        }

    }
}
