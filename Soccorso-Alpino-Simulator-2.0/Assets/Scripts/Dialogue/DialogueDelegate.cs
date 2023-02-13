using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDelegate : MonoBehaviour
{

    public DialoguePrefab CurrentDialogue;

    private int _currentDialogueIndex = -1;
    
    public List<DialoguePrefab> Dialogues = new List<DialoguePrefab>();

    private DialogueController _dialogueController;
    
    
    private void Start()
    {
        CurrentDialogue = Dialogues[0];
        _currentDialogueIndex = 0;
        _dialogueController = FindObjectOfType<DialogueController>();
    }

    public void SetDialogue()
    {
        _dialogueController.SetDialogue(CurrentDialogue);
    }

    public void NextDialogue()
    {
        _currentDialogueIndex++;
        CurrentDialogue = Dialogues[_currentDialogueIndex];
    }
    
    
}
