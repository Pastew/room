using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : Interactable
{
    public bool closed = true;
    public Vector3 endRotationEuler = Vector3.zero;

    private float openingRotationSpeed = 2f;
    private float closingRotationSpeed = 1f;

    private Quaternion endRotation;
    private Quaternion startRotation;

    protected new void Awake()
    {
        base.Awake();
        startRotation = transform.localRotation;

        endRotation = Quaternion.Euler(endRotationEuler);
        timeNeededToSelect = 1.5f;
        distanceRequiredToInteract = 2.6f;
    }

    protected override void InvokeAction()
    {
        SmoothRotation smoothRotation = gameObject.AddComponent<SmoothRotation>();
        if (closed)
            smoothRotation.Setup(startRotation, endRotation, openingRotationSpeed);
        else
            smoothRotation.Setup(endRotation, startRotation, closingRotationSpeed);

        closed = !closed;
    }
}
