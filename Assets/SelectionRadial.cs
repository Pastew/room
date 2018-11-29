using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectionRadial: MonoBehaviour
{
    private Image image;

    private void Start()
    {
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    // From 0.0 to 1.0
    public void SetProgress(float progress)
    {
        image.fillAmount = progress;
    }

    internal void OnExitWithNoSuccess()
    {
        SetProgress(0);
    }

    internal void OnInvokeAction()
    {
        SetProgress(0);
    }
}
