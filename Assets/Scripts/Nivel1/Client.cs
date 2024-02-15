using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Client : MonoBehaviour
{
    public List<int> requiredItems = new List<int>(); // Correct combination of item IDs
    public int clientId; // Unique ID for each client
    private bool isColliding = false;

    private void Update()
    {
        if (isColliding == true && Input.GetKeyDown(KeyCode.F))
        {
            // Check if player has exactly the required items, no more, no less
            if (PlayerInventory.instance.items.Count == requiredItems.Count && requiredItems.All(id => PlayerInventory.instance.items.Contains(id)))
            {
                // Correct combination
                Debug.Log("Correct items delivered");
                PlayerInventory.instance.RemoveItems(requiredItems); // Remove the correct items

                if (clientId == 3) // Specific logic for client 3
                {
                    Debug.Log("Correct, puzzle completed");
                }
            }
            else
            {
                // Incorrect combination or extra items present, remove them either way
                Debug.Log("Error, incorrect items or extra items present");
                PlayerInventory.instance.RemoveItems(PlayerInventory.instance.items.ToList()); // Attempt to remove all items player has, adjusting for actual game logic
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isColliding = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isColliding = false;
    }
}
