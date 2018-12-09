using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Translates object from it's current position by given Vector3
// After transition is completed Vector3 flips and next time object will go back to it's origin position
public class SmoothSlide : Interactable
{
    public Vector3 slideVector = Vector3.zero;
    public float slideSpeed = 1f;

    protected override void InvokeAction()
    {
        Vector3 slideVector = new Vector3(0, 0, 1.7f);
        SmoothTransition smoothTransition = gameObject.AddComponent<SmoothTransition>();

        Vector3 startPos = transform.localPosition;
        Vector3 endPos = transform.localPosition + slideVector;
        smoothTransition.SetupParameters(startPos, endPos, slideSpeed);

        slideVector *= -1;
    }
}
