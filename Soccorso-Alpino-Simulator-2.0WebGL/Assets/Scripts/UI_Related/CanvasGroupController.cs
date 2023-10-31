using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupController : MonoBehaviour
{
    public CanvasGroup CanvasGroup;

    private void Awake()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
    }

    public void EnableCanvasGroup()
    {
        CanvasGroup.alpha = 1f;
        CanvasGroup.blocksRaycasts = true;
        CanvasGroup.interactable = true;
    }

    public void DisableCanvasGroup()
    {
        CanvasGroup.alpha = 0f;
        CanvasGroup.blocksRaycasts = false;
        CanvasGroup.interactable = false;
    }

}
