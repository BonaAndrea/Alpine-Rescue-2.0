using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitaController : SceneController
{
    [SerializeField]
    private Material _skyboxDaylightMaterial;
    [SerializeField]
    private Material _skyboxNighttimeMaterial;

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
}
