using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : Grabbable {

    public void takeShot()
    {
        GetComponent<Animator>().enabled = true;
        Destroy(putDownPlace);
        Destroy(gameObject, 2);
    }
}
