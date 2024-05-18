using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public SpriteRenderer speakerImage;
    public TextMeshPro dialogueText;
    private Dialogue.DialogueLine[] dialogueLines;
    private int currentLineIndex;
    public GameManager gameManager;
    public GameObject dialogueBox;
    public bool isTalking;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        dialogueLines = new Dialogue.DialogueLine[0];
        currentLineIndex = 0;
        
    }
    void Update()
    {
        // Check if the "F" key was pressed and there is an active dialogue
        if (Input.GetKeyDown(KeyCode.F) && isTalking == true)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (isTalking != true)
        {
            dialogueLines = dialogue.dialogueLines;
            currentLineIndex = 0;
            DisplayNextSentence();
            Debug.Log("Has iniciado el dialogo");
            dialogueBox.SetActive(true);
            isTalking = true;


        }
    }

    public void DisplayNextSentence()
    {
        // Check if the currentLineIndex has exceeded the array bounds
        if (currentLineIndex >= dialogueLines.Length)
        {
            EndDialogue();
            return;
        }

        Dialogue.DialogueLine line = dialogueLines[currentLineIndex];
        speakerImage.sprite = line.speakerImage;
        dialogueText.text = line.sentence;

        // Move to the next line
        currentLineIndex++;
    }

    void EndDialogue()
    {
        // Handle the end of the dialogue, maybe resetting or triggering other events
        gameManager.isTalking = false;
        
        if (gameManager.Conditionsanimation[0] == false)
        {
            gameManager.Conditionsanimation[0] = true;
        }
        dialogueBox.SetActive(false);
        isTalking = false;
        Debug.Log("Ha terminado el dialogo");
    }
}