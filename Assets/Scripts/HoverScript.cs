using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverScript : MonoBehaviour
{
    private float hoverForce = 4.3f;
    public Transform[] hoverPoints;
    public float height = 4f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        foreach (Transform t in hoverPoints)
        {
            if (Physics.Raycast(t.position, Vector3.down, height))
            {
                rb.AddForceAtPosition(Vector3.up * hoverForce, t.position);
            }

            if (!Physics.Raycast(t.position, Vector3.down, height*2))
            {
                rb.AddForceAtPosition(Vector3.down * hoverForce * 2, t.position);
            }
        }
    }
}
