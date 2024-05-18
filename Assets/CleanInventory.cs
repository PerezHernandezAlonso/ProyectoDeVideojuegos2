using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class CleanInventory : MonoBehaviour
{
    public PlayerInventory player;
    public bool isColliding;
    public Dialogue dialogo;
    public DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding == true && Input.GetKeyDown(KeyCode.F))
        {
            player.RemoveItems(PlayerInventory.instance.items.ToList());
            dialogueManager.StartDialogue(dialogo);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isColliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }
}
