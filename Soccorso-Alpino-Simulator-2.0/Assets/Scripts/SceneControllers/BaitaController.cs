using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class BaitaController : SceneController
{
    [SerializeField]
    private Material _skyboxDaylightMaterial;
    [SerializeField]
    private Material _skyboxNighttimeMaterial;

    [SerializeField]
    private TransitionController _transitionController;

    private TaskController _taskController;

    [SerializeField]
    private PlayableDirector _pD;

    [SerializeField]
    private TimelineAsset[] _cutscenes;
    void Start()
    {

        _taskController = GetComponent<TaskController>();

        if(GameValues.Scenery == 1)
        {
            RenderSettings.skybox = _skyboxDaylightMaterial;
            _taskController.ToggleTaskStatus("MountainRescue");
            _taskController.ToggleTaskOnSuccess("MountainRescue");
        }
        else if(GameValues.Scenery == 2)
        {
            RenderSettings.skybox = _skyboxNighttimeMaterial;
            _taskController.ToggleTaskStatus("DogRescue");
            _taskController.ToggleTaskOnSuccess("DogRescue");
        }

        if (!_pD)
        {
            _pD = FindAnyObjectByType<PlayableDirector>();
        }
        _pD.Play();
    }

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

    public void LoadNextScene()
    {
        int sceneToLoad = 0;
        if(GameValues.Scenery == 1)
        {
            sceneToLoad = SRScenes.Montagna_Elicottero;
        }
        else if (GameValues.Scenery == 2)
        {
            sceneToLoad = SRScenes.CasaParenti;
        }
        StartCoroutine(LoadNewScene(sceneToLoad));
    }

    public void PlayEndCutscene()
    {
        if(GameValues.Scenery == 1)
        {
            _pD.playableAsset = _cutscenes[0];
        }
        else if(GameValues.Scenery == 2)
        {
            _pD.playableAsset = _cutscenes[1];
        }

        _pD.Play();
    }

}
