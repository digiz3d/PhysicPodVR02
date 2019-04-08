using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestLapBlinking : MonoBehaviour {

    private Text osef;

    private void Start()
    {
        osef = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update () {
        float alpha = (Mathf.Sin(Time.time*5) + 1) / 2;
        osef.color = new Color(osef.color.r, osef.color.g, osef.color.b, alpha);
	}
}
