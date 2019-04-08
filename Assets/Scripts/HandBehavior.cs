using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBehavior : MonoBehaviour
{
    public bool Grabbing = false;
    public float diffY = 0f;

    public float OriginalY = 0f;
    public OVRInput.Button origin;

    public AudioClip VibeClip;

    void Update()
    {
        if (OVRInput.GetDown(origin))
        {
            Grabbing = true;
            OriginalY = transform.parent.transform.localPosition.y;

            if (origin.Equals(OVRInput.Button.SecondaryHandTrigger))
                OVRHaptics.Channels[1].Mix(new OVRHapticsClip(VibeClip));
            if (origin.Equals(OVRInput.Button.PrimaryHandTrigger))
                OVRHaptics.Channels[0].Mix(new OVRHapticsClip(VibeClip));
        }

        if (OVRInput.GetUp(origin))
        {
            Grabbing = false;
            diffY = 0f;
        }

        if (Grabbing)
        {
            diffY = transform.parent.transform.localPosition.y - OriginalY;
        }
    }
}
