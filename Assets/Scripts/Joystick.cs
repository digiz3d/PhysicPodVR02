using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    [SerializeField]
    private float maxY = 1.3f;
    [SerializeField]
    private float minY = 1.1f;

    [SerializeField]
    private HandBehavior grabbingHand;

    private float power = 0f;
    public float Power { get { return power; } }

    [SerializeField]
    private Transform thruster;
    [SerializeField]
    private Rigidbody rb;

    private float grabbedPositionY;
    private float newY = 0f;

    private void Update()
    {
        if (grabbingHand != null && grabbingHand.Grabbing)
        {
            newY = Mathf.Clamp(grabbedPositionY + grabbingHand.diffY, minY, maxY);
            transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
        }
        power = Mathf.InverseLerp(minY, maxY, newY);
    }

    private void FixedUpdate()
    {
        //Debug.Log(rb.velocity.magnitude);
        rb.AddForceAtPosition(rb.transform.forward * power * 500f, thruster.position, ForceMode.Acceleration);
    }

    private void OnTriggerStay(Collider other)
    {
        HandBehavior hb = other.gameObject.GetComponent<HandBehavior>();
        if (grabbingHand == null && hb != null && hb.Grabbing)
        {
            grabbingHand = hb;
            grabbedPositionY = transform.localPosition.y;
        }
        if (grabbingHand != null && !grabbingHand.Grabbing)
        {
            grabbingHand = null;
        }
    }
}
