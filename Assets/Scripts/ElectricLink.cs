using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricLink : MonoBehaviour {	
	// Update is called once per frame
	void Update () {
        float newRotationX = Random.Range(0f, 360f);
        transform.localRotation = Quaternion.Euler(new Vector3(newRotationX, 0, 90));
	}
}
