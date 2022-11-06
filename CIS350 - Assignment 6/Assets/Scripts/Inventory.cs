using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IInventoySystem
{
    [SerializeField] public List<InventoryItem> inventory;


    public void AddItem(int id, string name)
    {
        InventoryItem newItem = new InventoryItem();
        newItem.id = id;
        newItem.name = name;

        inventory.Add(newItem);
    }
}
