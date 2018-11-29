using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Interactable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    // seconds
    public float timeNeededToSelect = 2f;

    protected bool userGazingAtMe = false;

    // seconds
    private float timeLeftToSelect;
    private SelectionRadial selectionRadial;

    private void Awake()
    {
        selectionRadial = FindObjectOfType<SelectionRadial>();
    }

    protected virtual void Update()
    {
        if (userGazingAtMe && timeLeftToSelect > 0f)
        {
            timeLeftToSelect -= Time.deltaTime;

            float progress = (timeNeededToSelect - timeLeftToSelect) / timeNeededToSelect;
            selectionRadial.SetProgress(progress);

            if (timeLeftToSelect <= 0f)
            {
                InvokeAction();
                selectionRadial.OnInvokeAction();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        userGazingAtMe = true;
        timeLeftToSelect = timeNeededToSelect;
        PointerEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        userGazingAtMe = false;
        timeLeftToSelect = timeNeededToSelect;
        selectionRadial.OnExitWithNoSuccess();
        PointerExit();
    }


    // Implement this if you want to do something additional on pointer enter
    protected virtual void PointerEnter() { }

    // Implement this if you want to do something additional on pointer enter
    protected virtual void PointerExit() { }

    protected virtual void InvokeAction() { }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.LogError("OnPointerClick invoked.");
    }
}