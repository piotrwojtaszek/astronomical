using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomSocket : XRSocketInteractor
{
    public Transform star;
    public bool isFilled = false;
    ParticleSystem particle;
    ConsteletionManager consteletionManager;
    List<InputDevice> inputDevices = new List<InputDevice>();
    protected override void Start()
    {
        base.Start();
        CreateParticle();
        consteletionManager = GetComponentInParent<ConsteletionManager>();
        consteletionManager.socketList.Add(this);
    }
    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Controller, inputDevices);
        foreach (var device in inputDevices)
        {
            UnityEngine.XR.HapticCapabilities capabilities;
            if (device.TryGetHapticCapabilities(out capabilities))
            {
                if (capabilities.supportsImpulse)
                {
                    uint channel = 0;
                    float amplitude = 0.25f;
                    float duration = 0.05f;
                    device.SendHapticImpulse(channel, amplitude, duration);
                }
            }
        }
        base.OnSelectEntered(interactable);
        star = interactable.transform;
        isFilled = true;
        if (particle != null)
            Destroy(particle);
        CreateCompleteParticle();
        consteletionManager.CheckIfSolved();
    }
    protected override void OnSelectExiting(XRBaseInteractable interactable)
    {
        base.OnSelectExiting(interactable);
        star = transform;
        isFilled = false;
        CreateParticle();
    }

    void CreateParticle()
    {
        ParticleSystem particleSystem = Resources.Load<ParticleSystem>("Prefabs/Others/EmptySocketParticle");
        particle = Instantiate(particleSystem);
        particle.transform.position = transform.position;
    }

    void CreateCompleteParticle()
    {
        ParticleSystem particleSystem = Resources.Load<ParticleSystem>("Prefabs/Others/CompletedSocket");
        ParticleSystem obj = Instantiate(particleSystem);
        obj.transform.position = transform.position;
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Handles.Label(transform.position, transform.name);
        Handles.SphereCap(0, transform.position, Quaternion.identity, transform.localScale.x / 2f);
#endif
    }
}
