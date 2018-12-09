using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutDownPlace : Interactable
{
    protected override void InvokeAction()
    {
        Hand hand = FindObjectOfType<Hand>();
        GameObject heldObject = hand.transform.GetChild(0).gameObject;
        heldObject.GetComponent<Grabbable>().PutBackOnPlace();
        Destroy(gameObject);
    }
}
