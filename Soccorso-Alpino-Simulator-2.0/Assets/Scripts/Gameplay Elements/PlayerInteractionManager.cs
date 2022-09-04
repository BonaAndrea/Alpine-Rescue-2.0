using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.EventSystems;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] private bool _debugRay;
    [SerializeField] private float _interactionDistance;

    [SerializeField] private RawImage _target;

    public Interactive _pointingInteractive;
    private Grabbable _pointingGrabbable;

    [SerializeField]
    private CharacterController _fpsController;

    private Vector3 _rayOrigin;

    private Interactive _interactiveObject = null;
    private bool IsDialogue = false;
    private bool locked = true;
    private bool UIenabled = true;

    void Update()
    {
        _rayOrigin = _fpsCameraT.position + _fpsController.radius * _fpsCameraT.forward;

        if (locked)
            CheckInteraction();

        if (UIenabled)
            UpdateUITarget();

        if (_debugRay)
            DebugRaycast();
    }

    private void CheckInteraction()
    {

        Ray ray = new Ray(_rayOrigin, _fpsCameraT.forward);
        RaycastHit hit;

        if (IsDialogue == true)
        {
            //this.gameObject.GetComponent<FirstPersonCharacterControllerSOUND>().SetLocked(true);
            if (Input.GetMouseButtonDown(0))
            {
                //GameObject.FindObjectOfType<DialogueManager>().DisplayNextSentence();

            }

        }
        else
        {
            //this.gameObject.GetComponent<FirstPersonCharacterControllerSOUND>().SetLocked(false);


        }
        if (_interactiveObject != null && Input.GetMouseButtonDown(0))
        {

            //Drop();
            return;
        }

        if (Physics.Raycast(ray, out hit, _interactionDistance) && IsDialogue == false && !EventSystem.current.IsPointerOverGameObject())
        {

            //Check if is interactable
            _pointingInteractive = hit.transform.GetComponent<Interactable>();
            
            //Check if is grabbable
            _pointingGrabbable = hit.transform.GetComponent<Grabbable>();

        }
        //If NOTHING is detected set all to null
        else
        {
            _pointingInteractive = null;
            _pointingGrabbable = null;
        }
    }

    public bool GetTorchStatus()
    {
        return transform.Find("Torcia").GetComponent<Light>().enabled;
    }

    private void UpdateUITarget()
    {
        if (_pointingInteractive)
            _target.color = Color.red;
        else
            _target.color = Color.black;
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
        if (!UIenabled)
        {
            //gameObject.GetComponent<FirstPersonCharacterController>().HidePointer();
        }
        if (UIenabled)
        {
            //gameObject.GetComponent<FirstPersonCharacterController>().ShowPointer();
        }
        UIenabled = valore;
    }
    public bool GetUIVisible()
    {
        return UIenabled;
    }
    public void SetLocked(bool valore)
    {
        locked = valore;
        //gameObject.GetComponent<FirstPersonCharacterControllerSOUND>().SetLocked(valore);
    }
    public bool GetUnlocked()
    {
        return locked;
    }
    public void SetTorchStatus(bool status)
    {
        transform.Find("Torcia").GetComponent<Light>().enabled = status;
    }
}