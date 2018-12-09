using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    internal GameObject GetHeldGameObject()
    {
        if (transform.childCount == 0)
            return null;
        else
            return transform.GetChild(0).gameObject;
    }
}
