using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkModeManager : MonoBehaviour
{

    public enum WalkMode { VRLookWalk, Footprints };

    private WalkMode currentWalkMode = WalkMode.Footprints;

    private Player player;
    public GameObject footprints;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        if(footprints == null)
        {
            Debug.LogError("Set Footprints gameobject in WalkModeManager!!!");
        }
    }

    public void SetWalkMode(WalkMode newWalkMode)
    {
        if (newWalkMode == currentWalkMode)
        {
            return;
        }

        SetWalkModeVRLookWalk(false);
        SetWalkModeFootprints(false);

        switch (newWalkMode)
        {
            case WalkMode.Footprints:
                SetWalkModeFootprints(true);
                break;
            case WalkMode.VRLookWalk:
                SetWalkModeVRLookWalk(true);
                break;

        }
        currentWalkMode = newWalkMode;
    }

    private void SetWalkModeVRLookWalk(bool turnedOn)
    {
        player.GetComponent<CharacterController>().enabled = turnedOn;
        player.GetComponent<VRLookWalk>().enabled = turnedOn;
    }

    private void SetWalkModeFootprints(bool turnedOn)
    {
        footprints.gameObject.SetActive(turnedOn);
    }
}
