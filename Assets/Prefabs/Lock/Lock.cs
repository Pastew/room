using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour {

    public int[] correctCode;
    public int[] currentCode;

    public void UpdateCode(int index, int value)
    {
        currentCode[index] = value;
        
        for (int i = 0; i < correctCode.Length; ++i)
        {
            if (correctCode[i] != currentCode[i])
                return;
        }

        CorrectCodeEntered();
    }

    private void CorrectCodeEntered()
    {
        StartOpenLockAnimation();
        Destroy(gameObject, 2.5f);
    }

    private void StartOpenLockAnimation()
    {
        GetComponent<Animator>().enabled = true;
    }
}
