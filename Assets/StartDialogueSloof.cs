using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogueSloof : MonoBehaviour
{
    public bool isColliding;
    public DialogueManager dialogueManager;
    public Dialogue dialogoSloof;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
   
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding == true)
        {
            if (Input.GetKeyDown(KeyCode.F) == true && dialogueManager.isTalking == false)
            {
                dialogueManager.StartDialogue(dialogoSloof);
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
