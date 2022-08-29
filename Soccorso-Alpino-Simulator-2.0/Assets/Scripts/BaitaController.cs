using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitaController : SceneController
{
    [SerializeField]
    private Material _skyboxDaylightMaterial;
    [SerializeField]
    private Material _skyboxNighttimeMaterial;

    void Start()
    {
        if(GameValues.Scenery == 1)
        {
            RenderSettings.skybox = _skyboxDaylightMaterial;
        }
        else if(GameValues.Scenery == 2)
        {
            RenderSettings.skybox = _skyboxNighttimeMaterial;
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
