using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnginesRotation : MonoBehaviour
{
    
    [SerializeField]
    private Joystick leftJoystick;

    [SerializeField]
    private Joystick rightJoystick;
    
    [SerializeField]
    private float maxRotationAngle = 20f;

    private float initialRotationZ = 0f;
    
    void Update()
    {
        //float totalPower = leftJoystick.Power - rightJoystick.Power;
        float rotationFromLeft = Mathf.Lerp(initialRotationZ, -maxRotationAngle, leftJoystick.Power);
        float rotationFromRight = Mathf.Lerp(initialRotationZ, maxRotationAngle, rightJoystick.Power);
        float newRotation = rotationFromLeft + rotationFromRight;
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, newRotation);
    }

        /*
    [Range(0,1)]
    public float leftPower, rightPower;

    private void Update()
    {
        float rotationFromLeft = Mathf.Lerp(initialRotationZ, -maxRotationAngle, leftPower);
        float rotationFromRight = Mathf.Lerp(initialRotationZ, maxRotationAngle, rightPower);
        float newRotation = rotationFromLeft + rotationFromRight;
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, newRotation);
    }
    */
}
