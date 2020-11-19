using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomSocket : XRSocketInteractor
{
    Transform star;
    private IEnumerator coroutine;

    protected override void OnHoverEntered(XRBaseInteractable interactable)
    {
        base.OnHoverEntered(interactable);
        star = interactable.transform;
        attachTransform.position = star.position;
        coroutine = UpdateAttachTransform();
        StartCoroutine(coroutine);
    }
    protected override void OnHoverExited(XRBaseInteractable interactable)
    {
        base.OnHoverExited(interactable);
        StopCoroutine(coroutine);
    }

    IEnumerator UpdateAttachTransform()
    {
        while (star != null)
        {
            yield return new WaitForSeconds(0.05f);
            attachTransform.position = star.position;
        }
    }
}
