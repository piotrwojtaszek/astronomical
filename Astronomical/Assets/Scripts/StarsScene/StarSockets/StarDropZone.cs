using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDropZone : MonoBehaviour
{
    public Transform interactableObject = null;
    public Transform socetInteractor;

    // Update is called once per frame
    void Update()
    {
        if (interactableObject != null)
            UpdateSocetPosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (interactableObject == null)
            interactableObject = other.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (interactableObject.GetInstanceID() == other.transform.GetInstanceID())
            interactableObject = null;
    }

    void UpdateSocetPosition()
    {
        socetInteractor.position = interactableObject.position;
    }
}
