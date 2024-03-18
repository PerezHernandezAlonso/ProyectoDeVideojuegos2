using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public Text speakerNameText;
    public Image speakerImage;
    public Text dialogueText;
    private Queue<Dialogue.DialogueLine> dialogueLines;

    void Start()
    {
        dialogueLines = new Queue<Dialogue.DialogueLine>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueLines.Clear();

        foreach (var line in dialogue.dialogueLines)
        {
            dialogueLines.Enqueue(line);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (dialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue.DialogueLine line = dialogueLines.Dequeue();
        speakerNameText.text = line.speakerName;
        speakerImage.sprite = line.speakerImage;
        dialogueText.text = line.sentence;
        
    }

    void EndDialogue()
    {
        
    }
}