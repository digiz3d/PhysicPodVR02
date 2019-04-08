using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodControl : MonoBehaviour {
    public Transform leftEngine;
    public Transform rightEngine;

    private Rigidbody rb;
    // Use this for initialization
    private void Start () {
        rb = GetComponentInChildren<Rigidbody>();
	}

    // Update is called once per frame
    private void Update () {
		
	}

    private void FixedUpdate()
    {
        rb.AddForceAtPosition(leftEngine.forward, leftEngine.position, ForceMode.Acceleration);
        rb.AddForceAtPosition(rightEngine.forward, rightEngine.position, ForceMode.Acceleration);
    }
}
