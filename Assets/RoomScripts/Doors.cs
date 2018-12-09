using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : Interactable {
    public bool closed = true;
    public Vector3 eulerRotation = Vector3.zero;

    private float openingRotationSpeed = 2f;
    private float closingRotationSpeed = 1f;
    private float openingSlideSpeed = 1f;
    private float closingSlideSpeed = 2f;

    private Quaternion endRotation;
    private Quaternion startRotation;

    protected new void Awake()
    {
        base.Awake();
        startRotation = transform.localRotation;

        // Calculate end Rotation
        Vector3 startEulerAngles = transform.rotation.eulerAngles;
        endRotation = Quaternion.Euler(eulerRotation);
        timeNeededToSelect = 2f;
    }

    protected override void InvokeAction()
    {
        // open close door
        SmoothRotation smoothRotation = gameObject.AddComponent<SmoothRotation>();
        if(closed)
            smoothRotation.Setup(startRotation, endRotation, openingRotationSpeed);
        else
            smoothRotation.Setup(endRotation, startRotation, closingRotationSpeed);

        // open/close corpse drawer
        GameObject corpseDrawerSupport = transform.parent.Find("corpse_drawer_support").gameObject;
        Vector3 slideVector = new Vector3(0, 0, 1.7f);

        SmoothTransition smoothTransition = corpseDrawerSupport.AddComponent<SmoothTransition>();
        Vector3 startPos = corpseDrawerSupport.transform.localPosition;

        if(closed)
            smoothTransition.SetupParameters(startPos, corpseDrawerSupport.transform.localPosition + slideVector, openingSlideSpeed);
        else
            smoothTransition.SetupParameters(startPos, corpseDrawerSupport.transform.localPosition - slideVector, closingSlideSpeed);

        closed = !closed;
    }
}
