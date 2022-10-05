using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HelicopterPoint : MonoBehaviour
{
    public bool IsReachable = false;
    public UnityEvent OnReach;
    public float MovementSpeed = 1f;
    public float RotationSpeed = 5f;
    
    public void SetReachable(bool value)
    {
        IsReachable = value;
    }

}
