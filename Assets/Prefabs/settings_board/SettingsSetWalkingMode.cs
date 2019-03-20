using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSetWalkingMode : Interactable
{
    WalkModeManager walkModeManager;

    public WalkModeManager.WalkMode walkMode;

    private new void Awake()
    {
        base.Awake();
        walkModeManager = FindObjectOfType<WalkModeManager>();
    }

    protected override void InvokeAction()
    {
        walkModeManager.SetWalkMode(walkMode);
        FindObjectOfType<SettingsBoard>().SetArrowPosition(transform.position);
    }
}
