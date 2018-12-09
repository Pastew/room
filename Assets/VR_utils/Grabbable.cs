using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : Interactable
{
    private Transform originalParent;
    private Vector3 originalLocalPosition;
    private GameObject putDownPlace;

    private void Awake()
    {
        originalParent = transform.parent;
        originalLocalPosition = transform.localPosition;
    }

    internal void PutBackOnPlace()
    {
        transform.parent = originalParent;
        transform.localPosition = originalLocalPosition;
    }

    private void Start()
    {
        putDownPlace = Resources.Load("PutDownPlace") as GameObject;
    }

    protected override void InvokeAction()
    {
        GameObject place = Instantiate(putDownPlace, originalParent, false);
        place.transform.localPosition = originalLocalPosition;

        Transform hand = FindObjectOfType<Hand>().transform;
        transform.parent = hand;
        transform.localPosition = Vector3.zero;
    }

}
