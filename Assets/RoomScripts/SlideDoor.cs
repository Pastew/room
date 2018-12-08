using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : Interactable
{
    public Vector3 slideVector = Vector3.right;

    protected override void InvokeAction()
    {
        transform.Translate(slideVector);
        slideVector *= -1;
    }
}
