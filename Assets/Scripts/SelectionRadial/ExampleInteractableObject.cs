using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExampleInteractableObject : Interactable
{
    float spinValue = 90;

	void Start () {
        print("Cube:Start");
	}

    new void Update () {
        base.Update();
        transform.Rotate(Vector3.up, spinValue * Time.deltaTime);
	}

    public void FipSpin()
    {
        spinValue = -spinValue;
    }

    protected override void PointerEnter()
    {
        print("Cube:Entered ");
    }

    protected override void PointerExit()
    {
        print("Cube:Exited ");
    }

    protected override void InvokeAction()
    {
        print("Some action");
        spinValue *= 10;
    }
}
