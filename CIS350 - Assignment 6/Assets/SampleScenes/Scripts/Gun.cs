using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Inventory inventoryRefrence;

    protected int damage;

    protected virtual void Awake()
    {
        damage = 10;
        inventoryRefrence.AddItem(6, gameObject.name);
    }

    public void Reload()
    {
        Debug.Log("Reloading Gun");
    }
}
