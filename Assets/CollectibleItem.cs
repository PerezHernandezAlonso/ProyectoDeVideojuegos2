using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Optionally, you can add logic here to update the collected items count
            GameManager.instance.IncrementItemsCollected();

            // Deactivate or destroy the item
            gameObject.SetActive(false); // Use this if you plan to reuse the item
            // Destroy(gameObject); // Use this if you don't plan to reuse the item
        }
    }
}
