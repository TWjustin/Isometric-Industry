using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Dictionary<string, Inventory> inventories;

    private void Start()
    {
        inventories = new Dictionary<string, Inventory>();
    }

    public void AddInventory(string identifier, Inventory inventory)
    {
        if (!inventories.ContainsKey(identifier))
        {
            inventories.Add(identifier, inventory);
        }
        else
        {
            Debug.LogWarning("An inventory with the same identifier already exists.");
        }
    }

    public Inventory GetInventory(string identifier)
    {
        if (inventories.ContainsKey(identifier))
        {
            return inventories[identifier];
        }
        else
        {
            Debug.LogWarning("No inventory found with the specified identifier.");
            return null;
        }
    }
}