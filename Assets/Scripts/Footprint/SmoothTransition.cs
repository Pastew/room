using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source: https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
public class SmoothTransition : MonoBehaviour {
    // Transforms to act as start and end markers for the journey.
    public Vector3 startPos;
    public Vector3 endPos;

    internal void SetupParameters(object startMarker, object endMarker, float walkSpeed)
    {
        throw new NotImplementedException();
    }

    // Movement speed in units/sec.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    public void SetupParameters(Vector3 startPos, Vector3 endPos, float speed)
    {
        this.startPos = startPos;
        this.endPos = endPos;
        this.speed = speed;
    }

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startPos, endPos);
    }

    // Follows the target position like with a spring
    void Update()
    {
        // Distance moved = time * speed.
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.localPosition = Vector3.Lerp(startPos, endPos, fracJourney);

        // Remove component once it's job is done
        if (Vector3.Distance(transform.localPosition, endPos) < 0.01f)
            Destroy(this);
            
    }
}