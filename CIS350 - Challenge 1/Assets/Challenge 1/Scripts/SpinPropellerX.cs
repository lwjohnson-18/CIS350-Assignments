/*
 * Lucas Johnson
 * Assignment 1 (Challenge 1)
 * Spins the plane's propeller
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
