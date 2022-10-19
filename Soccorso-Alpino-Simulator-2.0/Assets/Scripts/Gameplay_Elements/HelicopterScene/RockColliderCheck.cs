using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockColliderCheck : ColliderUtilities
{
    [SerializeField]
    private string _task;
    private TaskController _controller;
    public int CollisionNumber = 0;

    private void OnTriggerEnter(Collider other)
    {
        CollisionNumber++;
    }
    private void OnTriggerExit(Collider other)
    {
        CollisionNumber--;
    }
    private void Start()
    {
        _controller = FindObjectOfType<TaskController>();
    }

    public void FixedUpdate()
    {
        if(CollisionNumber <= 0)
        {
            _controller.SetTaskSatisfied(_task, true);
            _controller.ToggleTaskOnSuccess(_task);
        }
        else if(CollisionNumber > 0)
        {
            _controller.SetTaskSatisfied(_task, false);
            _controller.ToggleTaskOnFailure(_task);
        }
    }
}
