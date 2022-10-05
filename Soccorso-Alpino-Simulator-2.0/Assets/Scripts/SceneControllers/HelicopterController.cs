using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelicopterController : SceneController
{
    [SerializeField]
    private TransitionController _transitionController;
    [SerializeField]
    private Transform _helicopter;
    [SerializeField]
    private List<HelicopterPoint> _helicopterPoints = new List<HelicopterPoint>();

    void Start()
    {
        _transitionController = FindObjectOfType<TransitionController>();
    }

    void Update()
    {
        if(GameValues.GameMode == 1)
        {
            //update points ui
        }
    }

    private void FixedUpdate()
    {
        if (_helicopterPoints.Count <= 0 || !_helicopterPoints[0].IsReachable) return;
        if (Vector3.Distance(_helicopterPoints[0].transform.position, _helicopter.position) <= Vector3.kEpsilon && Quaternion.Angle(_helicopterPoints[0].transform.rotation, _helicopter.rotation) <= Quaternion.kEpsilon)
        {
            _helicopterPoints[0].OnReach.Invoke();
            _helicopterPoints.RemoveAt(0);
        }
        else
        {
            _helicopter.position = Vector3.MoveTowards(_helicopter.position, _helicopterPoints[0].transform.position, Time.deltaTime * _helicopterPoints[0].MovementSpeed);
            _helicopter.rotation = Quaternion.RotateTowards(_helicopter.rotation, _helicopterPoints[0].transform.rotation, Time.deltaTime * _helicopterPoints[0].RotationSpeed);
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
        StartCoroutine(LoadNewScene(SRScenes.MainMenu));
    }

}
