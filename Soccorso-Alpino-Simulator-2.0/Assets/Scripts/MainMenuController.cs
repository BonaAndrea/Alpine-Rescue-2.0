using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : SceneController
{

    [SerializeField]
    private TransitionController _transitionController;

    [SerializeField]
    private Button _helicopterPlayButton, _helicopterLearnButton;
    [SerializeField]
    private Button _caninePlayButton, _canineLearnButton;
    [SerializeField]
    private Button _avalanchePlayButton, _avalancheLearnButton;

    private IEnumerator LoadNewScene(int Scene)
    {
        while (_transitionController.IsTransitioning)
        {
            yield return null;
        }

        AsyncOperation progress = SceneManager.LoadSceneAsync(Scene);

        while (!progress.isDone)
        {
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _helicopterLearnButton.onClick.AddListener(() => PlaySceneMode(SRScenes.Baita, 1, 0));
        _helicopterPlayButton.onClick.AddListener(() => PlaySceneMode(SRScenes.Baita, 1, 1));
        _canineLearnButton.onClick.AddListener(() => PlaySceneMode(SRScenes.Baita, 2, 0));
        _caninePlayButton.onClick.AddListener(() => PlaySceneMode(SRScenes.Baita, 2, 1));
        _avalancheLearnButton.onClick.AddListener(() => PlaySceneMode(SRScenes.Valanga, 3, 0));
        _avalanchePlayButton.onClick.AddListener(() => PlaySceneMode(SRScenes.Valanga, 3, 1));
        GameValues.GameMode = 0;
        GameValues.Scenery = 0;
        GameValues.Score = 0;

    }
    public void PlaySceneMode(int sceneToLoad, int scenery, int mode)
    {
        _transitionController.TransitionFadeOut();
        GameValues.Scenery = scenery;
        GameValues.GameMode = mode;
        if (GameValues.GameMode == 1)
        {
            GameValues.Score = 50;
        }
        StartCoroutine(LoadNewScene(sceneToLoad));
    }

    private void Awake()
    {
        _transitionController.TransitionFadeIn();
    }

}
