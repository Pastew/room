using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprint : Interactable
{
    public float walkSpeed = 3;

    protected new void Awake()
    {
        base.Awake();
        timeNeededToSelect = 0.5f; // seconds
        distanceRequiredToInteract = 10f; // meters
    }

    protected override void InvokeAction()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        SmoothTransition smoothTransition = player.AddComponent<SmoothTransition>();

        Vector3 startPos = player.transform.position;
        Vector3 endPos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        smoothTransition.SetupParameters(startPos, endPos, walkSpeed);
    }
}
