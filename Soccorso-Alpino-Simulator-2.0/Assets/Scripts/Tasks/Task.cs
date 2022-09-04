using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Task : MonoBehaviour
{
    public string Name;
    public string[] Conditions;
    public bool Satisfied = false;

    public UnityEvent OnSuccess;
    public UnityEvent OnFailure;
}
