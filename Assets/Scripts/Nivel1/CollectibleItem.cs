using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public int itemId; // Unique ID for each item
    private bool isColliding = false;

    private void Update()
    {
        if (isColliding == true && Input.GetKeyDown(KeyCode.F))
        {
            PlayerInventory.instance.AddItem(itemId);
            // Optionally deactivate the item visually but do not destroy it
            // gameObject.SetActive(false);
            Debug.Log($"Item {itemId} collected");
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
