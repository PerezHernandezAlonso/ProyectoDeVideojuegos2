using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startanimationdialogue : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue dialogue;
    public bool libre = false;
    public bool isTalking = false;
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
        if (Input.GetKeyDown(KeyCode.F) && libre == false &&  gameManager.Conditionsanimation[0] == false)
        {
            dialogueManager.StartDialogue(dialogue);
            libre = true;
            isTalking = true;
        } else if ( Input.GetKeyDown(KeyCode.F) && gameManager.Conditionsanimation[0] == true)
        {
            Debug.Log("Prueba");
            sceneSelect.PlayGame();

        }
    }
}
