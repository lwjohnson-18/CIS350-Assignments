/*
 * Lucas Johnson
 * Assignment 6
 * Rifle Object
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Gun
{
    protected override void Awake()
    {
        base.Awake();
        type = "Rifle";
        damage = 20;
    }
}
