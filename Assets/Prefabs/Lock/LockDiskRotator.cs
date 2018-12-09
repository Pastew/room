using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDiskRotator : Interactable {

    public int dir = -1;
    public GameObject disk;

    private new void Awake()
    {
        base.Awake();
        canRunMultipleTimesInARow = true;
        timeNeededToSelect = 0.5f;
    }

    protected override void InvokeAction()
    {
        disk.GetComponent<LockDisk>().Rotate(dir); 
    }

}
