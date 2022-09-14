using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Task {
    public string Name;
    public string[] Conditions;
    public bool Satisfied = false;

    public UnityEvent OnSuccess;
    public UnityEvent OnFailure;
}

public class TaskController : MonoBehaviour
{
    public Task[] Tasks;
    public Dictionary<string, Task> TaskDictionary = new Dictionary<string, Task>();


    private void Awake()
    {
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        foreach(Task task in Tasks)
        {
            if (!TaskDictionary.ContainsKey(task.Name))
            {
                TaskDictionary.Add(task.Name, task);
            }
        }
    }

    public bool CheckTasks(List<string> taskForActivation)
    {
        bool result = true;

        foreach(string taskName in taskForActivation)
        {
            if (TaskDictionary.ContainsKey(taskName))
            {

                UpdateTaskStatus(TaskDictionary[taskName]);

                if (!TaskDictionary[taskName].Satisfied)
                {
                    result = false;
                    break;
                }
            }
            else
            {
                Debug.LogError("Task not in dictionary!");
            }
        }

        return result;
    }

    public void UpdateTaskStatus(Task toUpdate)
    {
        foreach(string condition in toUpdate.Conditions)
        {
            if (TaskDictionary.ContainsKey(condition))
            {
                if (!TaskDictionary[condition].Satisfied)
                {
                    toUpdate.Satisfied = false;
                    return;
                }
            }
        }
        toUpdate.Satisfied = true;
    }

    public void ToggleTaskStatus(string task)
    {
        if (!TaskDictionary.ContainsKey(task))
        {
            Debug.LogError("No such task!");
            return;
        }

        TaskDictionary[task].Satisfied = !TaskDictionary[task].Satisfied;

        foreach(Task value in TaskDictionary.Values)
        {
            if (value.Name == task)
            {
                UpdateTaskStatus(value);
            }
        }

    }

}
