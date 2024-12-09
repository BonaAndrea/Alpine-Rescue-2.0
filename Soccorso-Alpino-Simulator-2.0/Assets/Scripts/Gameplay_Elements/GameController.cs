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
    Inventory,
    Unset
};
public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;

    public GameState GameState
    {
        get { return gameState; }
        set
        {
            if (gameState != value)
            {
                gameState = value;
                OnGameStateChange();
            }
        }
    }
    public FirstPersonCharacter FirstPersonCharacter;
    public DialogueController DialogueController;
    private PlayableDirector[] _directors;
    private void Awake()
    {
        _directors = UnityEngine.Object.FindObjectsByType<PlayableDirector>(FindObjectsSortMode.None);
    }
    
    void Start()
    {
        FirstPersonCharacter = FindAnyObjectByType<FirstPersonCharacter>();
        DialogueController = GetComponent<DialogueController>();
    }

    private void OnGameStateChange()
    {
        if (gameState == GameState.Play)
        {
            FirstPersonCharacter.SetPointer(true);
        }
        else
        {
            FirstPersonCharacter.SetPointer(false);
        }
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
        _directors[0].Stop();
    }
    
    public void SetGameStateDialogue()
    {
        GameState = GameState.Dialogue;
        Cursor.visible = false;
    }
    
    public void SetGameStateCutscene()
    {
        GameState = GameState.Cutscene;
        Cursor.visible = false;
    }
    
    public void SetGameStateInventory()
    {
        GameState = GameState.Inventory;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
}
