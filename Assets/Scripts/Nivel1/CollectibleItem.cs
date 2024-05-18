using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleItem : MonoBehaviour
{
    public int itemId; // Unique ID for each item
    private bool isColliding = false;
    public Dialogue dialogo;
    public DialogueManager dialogueManager;

    private void Update()
    {
        if (isColliding == true && Input.GetKeyDown(KeyCode.F))
        {
            PlayerInventory.instance.AddItem(itemId);
            dialogueManager.StartDialogue(dialogo);
            Debug.Log($"Item {itemId} collected");
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
