using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    public List<int> items = new List<int>(); // Stores collected item IDs

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void AddItem(int itemId)
    {
        if (!items.Contains(itemId)) // Prevent duplicate items
        {
            items.Add(itemId);
        }
    }

    public bool RemoveItems(List<int> itemIds)
    {
        if (itemIds.TrueForAll(id => items.Contains(id)))
        {
            foreach (int id in itemIds)
            {
                items.Remove(id);
            }
            return true; // Successfully removed items
        }
        return false; // Failed to remove items (not all items were in inventory)
    }
}
