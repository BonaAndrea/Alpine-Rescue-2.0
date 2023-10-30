using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public enum GameState
{
    Play,
    Pause,
    Dialogue,
    Cutscene,
    Unset
};
public class GameController : MonoBehaviour
{
    public GameState GameState;
    public FirstPersonCharacter FirstPersonCharacter;
    public DialogueController DialogueController;
    private PlayableDirector[] _directors;
    private void Awake()
    {
        _directors = FindObjectsOfType<PlayableDirector>();
    }
    
    void Start()
    {
        FirstPersonCharacter = FindObjectOfType<FirstPersonCharacter>();
        DialogueController = GetComponent<DialogueController>();
    }

    public void SetGameStatePause()
    {
        GameState = GameState.Pause;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
    public void SetGameStatePlay()
    {
        GameState = GameState.Play;
        Cursor.visible = false;
    }
    
    public void SetGameStateDialogue()
    {
        GameState = GameState.Dialogue;
        Cursor.visible = false;
    }
    
    
}
