using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DemoScript : MonoBehaviour
{
    [FormerlySerializedAs("inventoryManager")] public Inventory inventory;
    public Item[] itemsToPickUp;

    public void PickUpItem(int id)
    {
        bool result = inventory.AddItem(itemsToPickUp[id]);
        if (result)
        {
            Debug.Log("Item added successfully");
        }
        else
        {
            Debug.Log("Inventory is full");
        }
    }
}
