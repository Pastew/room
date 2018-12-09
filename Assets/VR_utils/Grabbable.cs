using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : Interactable
{
    private Transform originalParent;
    private Vector3 originalLocalPosition;
    private GameObject putDownPlace;
    private GameObject hand;

    private void Awake()
    {
        originalParent = transform.parent;
        originalLocalPosition = transform.localPosition;
        hand = FindObjectOfType<Hand>().gameObject;
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

        transform.parent = hand.transform;
        transform.localPosition = Vector3.zero;
    }

    protected override void PointerEnter()
    {
        if (hand.GetComponent<Hand>().GetHeldGameObject() != null)
            PointerExit();
        else
            base.PointerEnter();
    }
}
