using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorUtilities : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ToggleParameter(string boolParam)
    {
        _animator.SetBool(boolParam, !_animator.GetBool(boolParam));
    }

}
