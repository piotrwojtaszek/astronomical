using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomSocket : XRSocketInteractor
{
    public Transform star;
    public bool isFilled=false;
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
        ParticleSystem particleSystem = Resources.Load<ParticleSystem>("Particle/EmptySocketParticle");
        particle = Instantiate(particleSystem);
        particle.transform.position = transform.position;
    }

    void CreateCompleteParticle()
    {
        ParticleSystem particleSystem = Resources.Load<ParticleSystem>("Particle/CompletedSocket");
        ParticleSystem obj = Instantiate(particleSystem);
        obj.transform.position = transform.position;
    }
}
