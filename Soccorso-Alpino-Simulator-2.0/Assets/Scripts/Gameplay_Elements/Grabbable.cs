using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : Interactive
{

    private Rigidbody _rigidbody;
    private Collider _collider;
    private Transform _parent;
    private Transform _playerTransform;
    private PlayerInteractionManager _interactionManager;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); 
        _collider = GetComponent<Collider>();
        _parent = transform.parent;
        _playerTransform = Camera.main.transform;
        _interactionManager = FindObjectOfType<PlayerInteractionManager>();
    }

    public override void Interact()
    {
        if (!IsInteractive) return;
        Grab(_playerTransform);
    }

    public void Grab(Transform grabber)
    {
        transform.parent = grabber;
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false;
        _collider.isTrigger = true;
        _interactionManager.GrabbedItem = this;
    }

    public void Release()
    {
        transform.parent = _parent;
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
        _collider.isTrigger = false;
    }

}
