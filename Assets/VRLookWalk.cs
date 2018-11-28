using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class VRLookWalk : MonoBehaviour {

    public Transform vrCamera;

    public float toggleAngle = 25.0f;
    public float maxSpeed = 3.0f;
    public float speedIncrease = 50f;

    private float speed;
    public bool moveForward;

    private CharacterController characterControlleer;

	void Start () {
        characterControlleer = GetComponent<CharacterController>();
        if (vrCamera == null) {
            Debug.LogWarning("Camera transform is not set. I will use main camera");
            vrCamera = Camera.main.transform;
        }
	}
	
	void Update () {
        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            speed += Time.deltaTime * speedIncrease;
        }
        else
        {
            speed -= Time.deltaTime * speedIncrease;
        }

        speed = Mathf.Clamp(speed, 0, maxSpeed);

        Vector3 forwardDirection = vrCamera.transform.TransformDirection(Vector3.forward);
        characterControlleer.SimpleMove(forwardDirection * speed);

    }
}
