using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Doublsb.Dialog;
using State = Doublsb.Dialog.State;

public class DialogueController : MonoBehaviour
{

    private List<string> CurrentDialogue;
    private string CurrentChar;

    private GameController _gameController;

    public DialogManager DialogManager;
    private DialogData _dd;
    private void Start()
    {
        _gameController = FindAnyObjectByType<GameController>();
    }
    
    
    public void SetDialogue(DialoguePrefab text, string charName)
    {
        CurrentDialogue = new List<string>(text.Dialogues);
        _dd = new DialogData(CurrentDialogue[0], charName, () => CloseDialogueBox());
    }
    public void OpenDialogueBox()
    {
        if (CurrentDialogue == null) return;
        DialogManager.Show(_dd);
        _gameController.GameState = GameState.Dialogue;
    
    }

    private void CloseDialogueBox()
    {
        _gameController.GameState = GameState.Play;
    }
}
