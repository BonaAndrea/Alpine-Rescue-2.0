using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    Play,
    Pause,
    Dialogue
};
public class GameController : MonoBehaviour
{
    public GameState GameState;
    public FirstPersonCharacter FirstPersonCharacter;
    public DialogueController DialogueController;
    void Start()
    {
        FirstPersonCharacter = FindObjectOfType<FirstPersonCharacter>();
        DialogueController = GetComponent<DialogueController>();
    }

    void Update()
    {
        if (GameState != GameState.Play)
        {
            
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
    }
    public void SetGameStateDialogue()
    {
        GameState = GameState.Dialogue;
    }
    
    
}
