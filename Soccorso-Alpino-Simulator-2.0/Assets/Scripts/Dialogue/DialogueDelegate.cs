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
        if (Dialogues.Count > 0)
        {
            CurrentDialogue = Dialogues[0];
            _currentDialogueIndex = 0;
        }

        _dialogueController = FindAnyObjectByType<DialogueController>();
    }

    public void SetDialogue()
    {
        if (CurrentDialogue == null)
        {
            if (Dialogues.Count > 0)
            {
                CurrentDialogue = Dialogues[0];
                _currentDialogueIndex = 0;
            }
        }
        _dialogueController.SetDialogue(CurrentDialogue, transform.name);
    }

    public void NextDialogue()
    {
        _currentDialogueIndex++;
        CurrentDialogue = Dialogues[_currentDialogueIndex];
    }
    
    public void SetDialoguePrefab(DialoguePrefab prefab)
    {
        Dialogues.Add(prefab);
    }
}
