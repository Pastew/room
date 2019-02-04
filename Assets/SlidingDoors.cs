using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoors : Interactable
{
    public bool closed = true;
    public Vector3 slideVector = Vector3.zero;

    public float openingSlideSpeed = 0.001f;
    public float closingSlideSpeed = 0.002f;

    protected new void Awake()
    {
        base.Awake();
        timeNeededToSelect = 1.5f;
        distanceRequiredToInteract = 2.6f;
    }

    protected override void InvokeAction()
    {
        SmoothTransition smoothTransition = gameObject.AddComponent<SmoothTransition>();
        Vector3 startPos = gameObject.transform.localPosition;

        if (closed)
            smoothTransition.SetupParameters(startPos, gameObject.transform.localPosition + slideVector, openingSlideSpeed);
        else
            smoothTransition.SetupParameters(startPos, gameObject.transform.localPosition - slideVector, closingSlideSpeed);

        closed = !closed;
    }
}
