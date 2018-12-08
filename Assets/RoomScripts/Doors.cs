using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : Interactable {

    int closed = 1;

    protected override void InvokeAction()
    {
        transform.Rotate(Vector3.up, 90 * closed);
        closed *= -1;
    }
}
