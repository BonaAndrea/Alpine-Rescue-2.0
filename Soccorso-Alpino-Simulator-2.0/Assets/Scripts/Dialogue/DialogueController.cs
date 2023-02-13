using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueController : MonoBehaviour
{

    private List<string> CurrentDialogue;
    
    [SerializeField]
    private TextMeshProUGUI  _text;
    [SerializeField]
    private RectTransform _rect;

    private GameController _gameController;
    
    private int _animating = 0;

    private int _y = 200;

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
    }
    
    
    public void SetDialogue(DialoguePrefab text)
    {
        CurrentDialogue = new List<string>(text.Dialogues);
    }
    public void OpenDialogueBox()
    {
        if (CurrentDialogue == null) return;
        _text.text = CurrentDialogue[0];
        _animating = 1;
        _gameController.GameState = GameState.Dialogue;
    }

    public void CloseDialogueBox()
    {
        _animating = -1;
        _gameController.GameState = GameState.Play;

    }
    
    void Update()
    {
        if (_animating == 0) return;
        Vector2 position = _rect.anchoredPosition;
        position.y += 100 * _animating * Time.fixedDeltaTime;
        _rect.anchoredPosition = position;
        switch (_animating)
        {
            case 1:
                if (_rect.anchoredPosition.y >= _y)
                {
                    _animating = 0;
                }
                break;
            case -1:
                if (_rect.anchoredPosition.y <= -_y)
                {
                    _animating = 0;
                }

                break;
        }

    }

    public void DisplayNextSentence()
    {
        if (CurrentDialogue.Count == 0) return;
        CurrentDialogue.RemoveAt(0);
        if (CurrentDialogue.Count >= 1)
        {
            _text.text = CurrentDialogue[0];
        }
        else
        {
            CloseDialogueBox();
        }
    }
}
