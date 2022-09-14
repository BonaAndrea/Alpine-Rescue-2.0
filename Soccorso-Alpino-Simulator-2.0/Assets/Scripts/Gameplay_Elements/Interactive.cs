using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactive : MonoBehaviour
{
    public bool IsInteractive = true;
    public List<string> TaskForActivation = new List<string>();

    public UnityEvent OnInteract;

    private TaskController _taskController;

    private void Start()
    {
        _taskController = FindObjectOfType<TaskController>();
    }

    public void Interact()
    {
        if (!IsInteractive) return;

            OnInteract.Invoke();
    }

    public void CheckInteractive()
    {
        IsInteractive = _taskController.CheckTasks(TaskForActivation);
    }

}
