using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : Interactable
{
    protected override void InvokeAction()
    {
        GameObject go = FindObjectOfType<Hand>().GetHeldGameObject(); 
        if(go == null)
        {
            print("User has empty hand");
            return;
        }

        Syringe syringe =  go.GetComponent<Syringe>();
        if (syringe != null)
            syringe.takeShot();
    }
}
