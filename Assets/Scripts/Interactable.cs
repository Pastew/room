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
    protected bool canRunMultipleTimesInARow = false;

    private GameObject player;

    protected void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected virtual void Update()
    {
        if (userGazingAtMe && timeLeftToSelect > 0f)
        {
            timeLeftToSelect -= Time.deltaTime;

            float progress = (timeNeededToSelect - timeLeftToSelect) / timeNeededToSelect;

            if (timeLeftToSelect <= 0f)
            {
                InvokeAction();
                if (canRunMultipleTimesInARow)
                {
                    timeLeftToSelect = timeNeededToSelect;
                }
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
        PointerExit();
    }


    // Implement this if you want to do something additional on pointer enter
    protected virtual void PointerEnter()
    {
        userGazingAtMe = true;
        timeLeftToSelect = timeNeededToSelect;
    }

    // Implement this if you want to do something additional on pointer enter
    protected virtual void PointerExit()
    {
        userGazingAtMe = false;
        timeLeftToSelect = timeNeededToSelect;
    }

    protected abstract void InvokeAction();

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.LogError("OnPointerClick invoked.");
    }
}