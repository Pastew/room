using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : Interactable {

    // 1 for yes, -1 for no
    public int closed = 1;
    public float rotationAngle = 90;

    protected override void InvokeAction()
    {
        transform.Rotate(Vector3.up, rotationAngle * closed);
        closed *= -1;
    }
}
