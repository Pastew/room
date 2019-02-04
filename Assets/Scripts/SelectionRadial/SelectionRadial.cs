using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectionRadial : MonoBehaviour
{
    private Image circleImage, pointImage, backgroundImage;
    private Color startingBackgroundColor;

    private GvrReticlePointer gvrReticlePointer;

    private void Update()
    {
        transform.localPosition = new Vector3(0, 0, gvrReticlePointer.ReticleDistanceInMeters);
    }

    private void Awake()
    {
        circleImage = transform.Find("Circle").GetComponent<Image>();
        pointImage = transform.Find("Point").GetComponent<Image>();
        backgroundImage = transform.Find("Background").GetComponent<Image>();
        // TODO: test if copy constructor works

        gvrReticlePointer = FindObjectOfType<GvrReticlePointer>();
        ShowBackground(false);
        print("selectionradial");
    }

    // From 0.0 to 1.0
    public void SetProgress(float progress)
    {
        circleImage.fillAmount = progress;
    }

    internal void OnExitWithNoSuccess()
    {
        SetProgress(0);
    }

    internal void OnInvokeAction()
    {
        SetProgress(0);
    }

    internal void ShowBackground(bool show)
    {
        backgroundImage.enabled = show;
    }
}
