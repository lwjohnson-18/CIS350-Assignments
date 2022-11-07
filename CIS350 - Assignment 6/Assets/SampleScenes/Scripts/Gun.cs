/*
 * Lucas Johnson
 * Assignment 6
 * Gun Superclass
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [HideInInspector] public string type;
    protected int damage;

    protected virtual void Awake()
    {
        type = "Gun";
        damage = 10;
    }

    public void Reload()
    {
        Debug.Log("Reloading Gun");
    }
}
