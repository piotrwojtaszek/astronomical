using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomSocket : XRSocketInteractor
{
    public Transform star;
    public bool isFilled = false;
    ParticleSystem particle;
    protected override void Start()
    {
        base.Start();
        CreateParticle();
    }
    protected override void OnSelectEntered(XRBaseInteractable interactable)
    {
        base.OnSelectEntered(interactable);
        star = interactable.transform;
        isFilled = true;
        if (particle != null)
            Destroy(particle);
        CreateCompleteParticle();
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
        Handles.Label(transform.position, transform.name);
        Handles.SphereCap(0, transform.position, Quaternion.identity, transform.localScale.x/2f);
    }
}
