using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : Interactable
{

    private Transform originalParent;
    private Vector3 originalLocalPosition;

    private void Awake()
    {
        originalParent = transform.parent;
        originalLocalPosition = transform.localPosition;
    }

    protected override void InvokeAction()
    {
        Transform hand = FindObjectOfType<Hand>().transform;
        transform.parent = hand;
        transform.localPosition = Vector3.zero;
    }

}
