using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    public string Tag;
    public string Task;
    private TaskController _controller;

    private void Start()
    {
        _controller = FindObjectOfType<TaskController>();
    }

    private void OnTriggerEnter(Collider other)
    {
            Transform[] children = other.GetComponentsInChildren<Transform>();

            Transform foundTransform = null;
            foreach (Transform child in children)
            {
                if (child.CompareTag(Tag))
                {
                    _controller.SetTaskSatisfied(Task, true);
                    _controller.ToggleTaskOnSuccess(Task);
                    break;
                }
            }
    }
}
