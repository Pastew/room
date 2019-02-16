using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsBoard : MonoBehaviour
{
    Transform arrow;

    void Awake()
    {
        arrow = transform.Find("arrow");            
    }

    public void SetArrowPosition(Vector3 newPos)
    {
        arrow.position = newPos;
    }
}
