using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotation : MonoBehaviour
{
    private float rotationSpeed;
    private Quaternion endRotation;
    private Quaternion startRotation;
    private float timeCount = 0.0f;

    public delegate void RotationFinishedDelegate();
    RotationFinishedDelegate methodToCallOnRotationFinished;

    public void Setup(Quaternion startRotation, Quaternion endRotation, float rotationSpeed, RotationFinishedDelegate methodToCallOnRotationFinished = null)
    {
        this.rotationSpeed = rotationSpeed;
        this.endRotation = endRotation;
        this.startRotation = startRotation;
        this.methodToCallOnRotationFinished = methodToCallOnRotationFinished;
    }

    void Update()
    {
        transform.localRotation = Quaternion.Slerp(startRotation, endRotation, timeCount * rotationSpeed);
        timeCount = timeCount + Time.deltaTime;

        if (Quaternion.Angle(transform.localRotation, endRotation) < 1)
        {
            if (null != methodToCallOnRotationFinished)
                methodToCallOnRotationFinished();

            Destroy(this);
        }
    }
}
