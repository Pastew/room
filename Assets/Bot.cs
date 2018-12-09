using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour {

    GvrEditorEmulator gvr;
    GvrPointerPhysicsRaycaster gvrPointer;

    public Transform[] lookAtObjects;

	void Start () {
        gvr = FindObjectOfType<GvrEditorEmulator>();
        gvrPointer = FindObjectOfType<GvrPointerPhysicsRaycaster>();
        //gvr.gameObject.SetActive(false);
        //gvrPointer.enabled = false;

        transform.LookAt(lookAtObjects[0]);
    }

    void Update () {
		
	}
}
