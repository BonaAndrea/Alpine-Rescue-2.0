using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
        if (toUpdate.Conditions.Length <= 0) return;
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

    public void SetTaskSatisfied(string task, bool value)
    {
        if (!TaskDictionary.ContainsKey(task))
        {
            Debug.LogError("No such task!");
            return;
        }

        TaskDictionary[task].Satisfied = value;

        /*foreach (Task t in TaskDictionary.Values)
        {
            if (t.Name == task)
            {
                UpdateTaskStatus(t);
            }
        }*/
    }

    public void ToggleTaskOnFailure(string task)
    {
        if(TaskDictionary.ContainsKey(task)){
            TaskDictionary[task].OnFailure.Invoke();
        }
    }

    public void ToggleTaskOnSuccess(string task)
    {
        if (TaskDictionary.ContainsKey(task))
        {
            TaskDictionary[task].OnSuccess.Invoke();
        }
    }

    public bool GetTaskStatus(string task)
    {
        bool result = true;
        if (!TaskDictionary.ContainsKey(task)) return false;

        if (TaskDictionary[task].Conditions.Length <= 0)
        {
            TaskDictionary[task].Satisfied = true;

            result = true;
        }
        else foreach (string condition in TaskDictionary[task].Conditions)
        {
            if (TaskDictionary.ContainsKey(condition))
            {
                if (!TaskDictionary[condition].Satisfied)
                {
                    TaskDictionary[task].Satisfied = false;
                        
                    result = false;
                    break;
                }
            }
        }

        if (result)
        {
            TaskDictionary[task].Satisfied = true;
        }
        
        return result;


    }
}
