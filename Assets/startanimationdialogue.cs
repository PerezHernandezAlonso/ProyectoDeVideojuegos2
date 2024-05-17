using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startanimationdialogue : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue dialogue;
    public GameManager gameManager;
    public SceneSelect sceneSelect;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        gameManager.Conditionsanimation[0] = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && gameManager.Conditionsanimation[0] == false)
        {
            dialogueManager.StartDialogue(dialogue);
            gameManager.Conditionsanimation[0] = true;
        } else 
        {
            if (Input.GetKeyDown(KeyCode.F) && dialogueManager.isTalking == false)
            {
                Debug.Log("Prueba");
                sceneSelect.PlayGame();
            }
            

        }
    }
}
