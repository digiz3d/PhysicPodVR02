using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerReceiver : MonoBehaviour
{
    [SerializeField]
    private Transform[] flaps;

    [SerializeField]
    private Joystick joystick;

    [SerializeField]
    private ParticleSystem fireParticleSystem;

    [SerializeField]
    private float noPowerAngle = -18f;
    [SerializeField]
    private float fullPowerAngle = 0f;

    [SerializeField]
    private float noPowerParticlesSpeed = 3f;
    [SerializeField]
    private float fullPowerParticlesSpeed = 6f;

    private ParticleSystem.MainModule ps;

    private AudioSource AS;
    [SerializeField]
    private float noAudioPitch = 0f;
    [SerializeField]
    private float fullAudioPitch = 2f;

    private void Start()
    {
        ps = fireParticleSystem.main;
        AS = GetComponent <AudioSource>();
    }

    void Update()
    {
        float power = Mathf.Clamp01(joystick.Power);
        //float power = Mathf.Cos(Time.time);
        //Debug.Log(power);
        foreach (Transform flap in flaps)
        {
            //float newRotation = Mathf.Clamp(power, closedRotationX, openedRotationX);
            float newRotation = Mathf.Lerp(noPowerAngle, fullPowerAngle, power);
            flap.localRotation = Quaternion.Euler(newRotation, flap.localRotation.eulerAngles.y, flap.localRotation.eulerAngles.z);
        }

        /*
        float newSizeZ = Mathf.Lerp(noPowerFireSizeZ, fullPowerFireSizeZ, power);
        fire.localScale = new Vector3(fire.localScale.x, fire.localScale.y, newSizeZ);
        */
        float newSpeed = Mathf.Lerp(noPowerParticlesSpeed, fullPowerParticlesSpeed, power);
        ps.startSpeed = newSpeed;

        float newPitch = Mathf.Lerp(noAudioPitch, fullAudioPitch, power);
        AS.pitch = newPitch;
    }
}
