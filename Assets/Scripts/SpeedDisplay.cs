using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour {

    [SerializeField]
    private Rigidbody rb;
    private Text txt;

    private void Start()
    {
        txt = GetComponent<Text>();
    }
    void Update () {
        Vector3 t = rb.velocity;
        t.y = 0;
        txt.text = Mathf.Round(t.magnitude*10).ToString();
	}
}
