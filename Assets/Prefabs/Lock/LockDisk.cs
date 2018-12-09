using UnityEngine;

public class LockDisk : MonoBehaviour {

    public int value = 0;

    public float rotationSpeed = 500f;

    SmoothRotation.RotationFinishedDelegate methodToCallOnRotationFinished;

    private void Awake()
    {
        methodToCallOnRotationFinished = OnRotationFinished;
    }

    internal void Rotate(int direction)
    {
        Quaternion startRotation = transform.localRotation;

        Vector3 eulerRotation = new Vector3(0, 0, 36 * direction);
        Quaternion endRotation = Quaternion.Euler(startRotation.eulerAngles + eulerRotation);

        SmoothRotation smoothRotation = gameObject.AddComponent<SmoothRotation>();
        smoothRotation.Setup(startRotation, endRotation, rotationSpeed, methodToCallOnRotationFinished);
        value -= direction; // There is minus, because rotating left increases the value

        if (value == -1)
            value = 9;

        if (value == 10)
            value = 0;
    }

    private void OnRotationFinished()
    {
        //print("rotation finished. code number = ");
    }

}
