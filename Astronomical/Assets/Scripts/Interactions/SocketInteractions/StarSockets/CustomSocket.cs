using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomSocket : XRSocketInteractor
{
    Transform star;
    private IEnumerator coroutine;

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable") && other.GetComponent<ObjectsInfo>() && interactable == null)
        {
            interactable.onSelectEnter(this);
        }
    }*/

    /* private void OnTriggerExit(Collider other)
     {
         if (other.CompareTag("Interactable") && other.transform == interactable)
         {
             interactable.picked = false;
             interactable = null;
         }
     }*/
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
