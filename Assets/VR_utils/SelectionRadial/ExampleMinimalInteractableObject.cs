using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleMinimalInteractableObject : Interactable
{
    protected override void InvokeAction()
    {
        print("action");
    }
}
