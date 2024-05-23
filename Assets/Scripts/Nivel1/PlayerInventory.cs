using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    public List<int> items = new List<int>(); // Stores collected item IDs
    public Sprite[] spriteObjetos; // Array of sprites corresponding to item IDs
    public GameObject[] objetos; // Array of GameObjects to change sprites
    public int maxItems = 3; // Maximum number of items the player can hold

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void AddItem(int itemId)
    {
        if (items.Count < maxItems && !items.Contains(itemId)) // Prevent duplicate items and exceed maxItems
        {
            items.Add(itemId);
            UpdateInventoryDisplay();
        }
        else
        {
            Debug.LogWarning("Cannot add more items. Inventory is full or item already exists.");
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
            UpdateInventoryDisplay();
            return true; // Successfully removed items
        }
        return false; // Failed to remove items (not all items were in inventory)
    }

    private void UpdateInventoryDisplay()
    {
        // Deactivate all item display objects
        foreach (GameObject obj in objetos)
        {
            obj.SetActive(false);
        }

        // Activate and update the sprites of the items the player has
        for (int i = 0; i < items.Count; i++)
        {
            int itemId = items[i];
            if (itemId >= 0 && itemId <= spriteObjetos.Length)
            {
                Sprite newItemSprite = spriteObjetos[itemId-1];
                GameObject targetObject = objetos[i];
                SpriteRenderer spriteRenderer = targetObject.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    spriteRenderer.sprite = newItemSprite;
                    targetObject.SetActive(true);
                    Debug.Log($"Item {itemId} sprite changed to {newItemSprite.name} at display slot {i}");
                }
                else
                {
                    Debug.LogError($"No SpriteRenderer found on GameObject {targetObject.name}");
                }
            }
            else
            {
                Debug.LogError("Item ID is out of bounds for spriteObjetos array");
            }
        }
    }
}