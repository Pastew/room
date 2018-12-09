using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Interactable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    protected float timeNeededToSelect = 1f; // seconds
    protected float distanceRequiredToInteract = 2f; // meters

    protected bool userGazingAtMe = false;

    private float timeLeftToSelect; // seconds

    private SelectionRadial selectionRadial;
    private GameObject player;

    protected void Awake()
    {
        selectionRadial = FindObjectOfType<SelectionRadial>();
        player = GameObject.FindGameObjectWithTag("Player");
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
        float distanceBetweenPlayerAndObject = Vector3.Distance(transform.position, player.transform.position);
        if (distanceBetweenPlayerAndObject <= distanceRequiredToInteract)
            PointerEnter();
        else
            print(transform.name + " is too far away: " + distanceBetweenPlayerAndObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (selectionRadial == null)
            selectionRadial = FindObjectOfType<SelectionRadial>(); // TODO: Find out why it is null sometimes

        PointerExit();
    }


    // Implement this if you want to do something additional on pointer enter
    protected virtual void PointerEnter()
    {
        userGazingAtMe = true;
        timeLeftToSelect = timeNeededToSelect;
        selectionRadial.ShowBackground(true);
    }

    // Implement this if you want to do something additional on pointer enter
    protected virtual void PointerExit()
    {
        userGazingAtMe = false;
        timeLeftToSelect = timeNeededToSelect;
        selectionRadial.ShowBackground(false);
        selectionRadial.OnExitWithNoSuccess();
    }

    protected abstract void InvokeAction();

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.LogError("OnPointerClick invoked.");
    }
}