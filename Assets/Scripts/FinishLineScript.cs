using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineScript : MonoBehaviour {
    [SerializeField]
    private CheckpointScript[] Checkpoints;

    private void OnTriggerEnter(Collider other)
    {
        PodRaceStatus podRacer = other.gameObject.GetComponent<PodRaceStatus>();
        if (podRacer != null)
        {
            podRacer.PassFinishLine(Checkpoints.Length);
        }
    }

    public string GetCheckpointsCount()
    {
        return Checkpoints.Length.ToString();
    }
}
