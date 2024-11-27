using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDelegate : MonoBehaviour
{
    public string TaskToCheck;

    private TaskController _taskController;

    [SerializeField]
    private Button _button;
    
    private void Start()
    {
        _taskController = FindAnyObjectByType<TaskController>();
        _button = GetComponent<Button>();
    }

    public void CheckAndEnableTask()
    {
        _button.interactable = !_taskController.GetTaskStatus(TaskToCheck);
        if (_taskController.GetTaskStatus(TaskToCheck))
        {
            _taskController.ToggleTaskOnSuccess(TaskToCheck);
        }
    }
    
    
    
}
