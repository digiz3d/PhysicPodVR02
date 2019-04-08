using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        PodRaceStatus podRacer = other.gameObject.GetComponent<PodRaceStatus>();
        if (podRacer != null)
        {
            podRacer.PassCheckpoint(this);
        }
    }
}
