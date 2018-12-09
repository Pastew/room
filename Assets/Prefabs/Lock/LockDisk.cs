using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDisk : MonoBehaviour {

    public int value = 0;
    public float rotationSpeed = 500f;

    internal void ChangeValue(int valueChange)
    {
        Quaternion startRotation = transform.localRotation;

        Vector3 eulerRotation = new Vector3(0, 0, 36 * valueChange);
        Quaternion endRotation = Quaternion.Euler(startRotation.eulerAngles + eulerRotation);

        SmoothRotation smoothRotation = gameObject.AddComponent<SmoothRotation>();
        smoothRotation.Setup(startRotation, endRotation, rotationSpeed);
        value += valueChange;


        if (value == -1)
            value = 9;

        if (value == 10)
            value = 0;
    }
}
