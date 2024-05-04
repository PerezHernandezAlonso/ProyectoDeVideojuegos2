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
    private GameManager gameManager;
    public GameObject dialogueBox;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        dialogueLines = new Dialogue.DialogueLine[0];
        currentLineIndex = 0;
        Debug.Log("Has iniciado el dialogo");
    }
    void Update()
    {
        // Check if the "F" key was pressed and there is an active dialogue
        if (Input.GetKeyDown(KeyCode.F))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        // Instead of clearing a queue, you reinitialize the array and reset the index
        dialogueLines = dialogue.dialogueLines;
        currentLineIndex = 0;
        gameManager.isTalking = true;
        DisplayNextSentence();
        Debug.Log("Estas aqui");
        dialogueBox.SetActive(true);
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
    }
}