using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.EventSystems;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] private bool _debugRay;
    [SerializeField] private float _interactionDistance;

    [SerializeField] private RawImage _target;

    [SerializeField]
    private Interactive _pointingInteractive;

    [HideInInspector]
    public Grabbable GrabbedItem;

    [SerializeField]
    private CharacterController _fpsController;

    private Vector3 _rayOrigin;
    private bool _isDialogueBoxOpen = false;
    private bool _locked = false;
    private bool _UIEnabled = true;

    void Update()
    {
        _rayOrigin = _fpsCameraT.position + _fpsController.radius * _fpsCameraT.forward;

        if (!_locked)
            CheckInteraction();

        if (_UIEnabled)
            UpdateUITarget();

        if (_debugRay)
            DebugRaycast();
    }

    private void CheckInteraction()
    {
        Ray ray = new Ray(_rayOrigin, _fpsCameraT.forward);
        RaycastHit hit;

        if (GrabbedItem == null && Physics.Raycast(ray, out hit, _interactionDistance) && !_isDialogueBoxOpen && !EventSystem.current.IsPointerOverGameObject())
        {
            _pointingInteractive = hit.transform.GetComponent<Interactive>();

        }
        else
        {
            _pointingInteractive = null;
        }

        /*if (_isDialogueBoxOpen)
        {
            //this.gameObject.GetComponent<FirstPersonCharacterControllerSOUND>().SetLocked(true);
            if (Input.GetMouseButtonDown(0))
            {
                //GameObject.FindObjectOfType<DialogueManager>().DisplayNextSentence();

            }

        }
        /*else
        {
            //this.gameObject.GetComponent<FirstPersonCharacterControllerSOUND>().SetLocked(false);


        }*/

        if (_pointingInteractive != null)
        {
            _pointingInteractive.CheckInteractive();
            if (Input.GetMouseButtonDown(0))
            {
                if(GrabbedItem!=null)
                {
                    GrabbedItem.Release();
                    GrabbedItem = null;
                }

                if (_pointingInteractive.IsInteractive)
                {
                    _pointingInteractive.Interact();
                }
            }
            return;
        }
        if(GrabbedItem != null)
        {
                if (Input.GetMouseButtonDown(0))
                {
                        GrabbedItem.Release();
                        GrabbedItem = null;
                }
                return;
        }

    }

    public bool GetTorchStatus()
    {
        return transform.Find("Torcia").GetComponent<Light>().enabled;
    }

    private void UpdateUITarget()
    {
        if (GrabbedItem != null)
        {
            _target.color = new Color(1, 1, 1, 0);
        }
        else
        {

            if (_pointingInteractive && _pointingInteractive.IsInteractive)
                _target.color = Color.red;
            else
                _target.color = Color.black;
        }
    }

    /*private void Drop()
    {
        if (_grabbedObject == null)
            return;

        _grabbedObject.transform.parent = _grabbedObject.OriginalParent;
        _grabbedObject.Drop();

        _target.enabled = true;
        _grabbedObject = null;
    }*/

    /*private void Grab(Grabbable grabbable)
    {

        _grabbedObject = grabbable;
        grabbable.transform.SetParent(_fpsCameraT);

        _target.enabled = false;
    }*/

    private void DebugRaycast()
    {
        Debug.DrawRay(_rayOrigin, _fpsCameraT.forward * _interactionDistance, Color.red);
    }
    
    public void SetUIVisible(bool valore)
    {
        _target.enabled = valore;
        if (!_UIEnabled)
        {
            //gameObject.GetComponent<FirstPersonCharacterController>().HidePointer();
        }
        if (_UIEnabled)
        {
            //gameObject.GetComponent<FirstPersonCharacterController>().ShowPointer();
        }
        _UIEnabled = valore;
    }
    public bool GetUIVisible()
    {
        return _UIEnabled;
    }
    public void SetLocked(bool valore)
    {
        _locked = valore;
    }
    public bool GetLocked()
    {
        return _locked;
    }
    public void SetTorchStatus(bool status)
    {
        transform.Find("Torcia").GetComponent<Light>().enabled = status;
    }
}