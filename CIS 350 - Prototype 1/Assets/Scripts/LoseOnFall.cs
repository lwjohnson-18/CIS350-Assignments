/*
* Lucas Johnson
* Prototype 1
* Ends Game when player falls
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOnFall : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -1)
        {
            ScoreManager.gameover = true;
        }
    }
}
