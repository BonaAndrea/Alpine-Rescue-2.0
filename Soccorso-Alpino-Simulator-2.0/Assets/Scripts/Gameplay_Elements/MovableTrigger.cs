using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovableTrigger : MonoBehaviour
{
    public UnityEvent OnTriggerEntered;

    [SerializeField]
    private GameObject _gameObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _gameObject)
        {
            OnTriggerEntered.Invoke();
        }
    }
}
