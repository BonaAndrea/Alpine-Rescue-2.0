using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaitaController : SceneController
{
    [SerializeField]
    private Material _skyboxDaylightMaterial;
    [SerializeField]
    private Material _skyboxNighttimeMaterial;

    [SerializeField]
    private TransitionController _transitionController;

    private TaskController _taskController;

    void Start()
    {

        _taskController = GetComponent<TaskController>();

        if(GameValues.Scenery == 1)
        {
            RenderSettings.skybox = _skyboxDaylightMaterial;
            _taskController.ToggleTaskStatus("MountainRescue");
        }
        else if(GameValues.Scenery == 2)
        {
            RenderSettings.skybox = _skyboxNighttimeMaterial;
            _taskController.ToggleTaskStatus("DogRescue");
        }
    }

    void Update()
    {
        if(GameValues.GameMode == 1)
        {
            //update points ui
        }
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

}
