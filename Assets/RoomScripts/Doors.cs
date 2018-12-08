using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : Interactable {
    public bool closed = true;
    public Vector3 eulerRotation = Vector3.zero;

    private float rotationSpeed = 0.5f;
    private Quaternion endRotation;
    private Quaternion startRotation;

    private void Awake()
    {
        startRotation = transform.rotation;

        // Calculate end Rotation
        Vector3 startEulerAngles = transform.rotation.eulerAngles;
        endRotation = Quaternion.Euler(eulerRotation);
    }

    protected override void InvokeAction()
    {
        SmoothRotation smoothRotation = gameObject.AddComponent<SmoothRotation>();
        if(closed)
            smoothRotation.Setup(startRotation, endRotation, rotationSpeed);
        else
            smoothRotation.Setup(endRotation, startRotation, rotationSpeed);

        closed = !closed;
    }
}
