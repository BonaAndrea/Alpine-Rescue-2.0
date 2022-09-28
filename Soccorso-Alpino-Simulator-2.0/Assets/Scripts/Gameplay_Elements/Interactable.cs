using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : Interactive
{
    public override void Interact()
    {
        if (!IsInteractive) return;

        OnInteract.Invoke();
    }

}
