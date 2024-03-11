using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Client : MonoBehaviour
{
    public List<int> requiredItems = new List<int>(); // Correct combination of item IDs
    public int clientId; // Unique ID for each client
    private bool isColliding = false;
    public TextMeshPro Texto;

    private void Update()
    {
        if (isColliding == true && Input.GetKeyDown(KeyCode.F))
        {
            // Check if player has exactly the required items, no more, no less
            if (PlayerInventory.instance.items.Count == requiredItems.Count && requiredItems.All(id => PlayerInventory.instance.items.Contains(id)))
            {
                // Correct combination
                Texto.text = "Correct items delivered";
                Debug.Log("Correct items delivered");
                PlayerInventory.instance.RemoveItems(requiredItems); // Remove the correct items

                if (clientId == 3) // Specific logic for client 3
                {
                    Texto.text = "Correct, puzzle completed";
                    Debug.Log("Correct, puzzle completed");
                }
            }
            else
            {
                // Incorrect combination or extra items present, remove them either way
                Texto.text = "Error, incorrect items or extra items present";
                Debug.Log("Error, incorrect items or extra items present");
                PlayerInventory.instance.RemoveItems(PlayerInventory.instance.items.ToList()); // Attempt to remove all items player has, adjusting for actual game logic
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isColliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isColliding = false;
    }
}
