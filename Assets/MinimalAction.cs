using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimalAction : Interactable
{
    protected override void InvokeAction()
    {
        print("action");
    }
}
