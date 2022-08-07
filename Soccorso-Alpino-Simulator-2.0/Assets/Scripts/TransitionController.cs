using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour
{
    public RawImage rawImage;
    public bool TransitionIn = true;
    public float DestinationX = 2500f;
    public float TransitionSpeed = 1f;
    public bool IsTransitioning = true;

    private void Update()
    {
        if (!IsTransitioning) return;
        if (TransitionIn)
        {
            if(rawImage.rectTransform.localPosition.x != DestinationX)
            {
                rawImage.rectTransform.localPosition += Vector3.right * TransitionSpeed;
            }
            else
            {
                IsTransitioning = false;
            }
        }
        if (!TransitionIn)
        {
            if (rawImage.rectTransform.localPosition.x != 0)
            {
                rawImage.rectTransform.localPosition += Vector3.left * TransitionSpeed;
            }
            else
            {
                IsTransitioning = false;
            }
        }
    }


    public void TransitionFadeIn()
    {
        IsTransitioning = true;
        TransitionIn = true;
    }
    public void TransitionFadeOut()
    {
        IsTransitioning = true;
        TransitionIn = false;
    }

}
