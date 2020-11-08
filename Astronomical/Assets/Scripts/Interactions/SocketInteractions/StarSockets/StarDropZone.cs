using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDropZone : MonoBehaviour
{
    [SerializeField]
    private Transform interactableObject = null;
    public Transform socetInteractor;
    private MeshRenderer meshRenderer;
    private Vector3 oldPostition;
    private StarConnector starConnector;
    private void Start()
    {
        starConnector = GetComponent<StarConnector>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if (interactableObject != null)
        {
            starConnector.SetLineRendererState(true);
            starConnector.SetOriginPoint(interactableObject);
            if (!interactableObject.GetComponent<Rigidbody>().isKinematic)
                UpdateSocetPosition();
        }
        else
        {
            starConnector.SetOriginPoint(socetInteractor);
            ResetSocketPosition();
            starConnector.SetLineRendererState(false);
        }
        if (oldPostition != socetInteractor.position)
            meshRenderer.enabled = true;
        else
            meshRenderer.enabled = false;
        oldPostition = socetInteractor.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            if (interactableObject == null)
            {
                interactableObject = other.transform;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            if (interactableObject.GetInstanceID() == other.transform.GetInstanceID())
            {
                interactableObject = null;
            }
        }
    }

    void UpdateSocetPosition()
    {
        socetInteractor.position = interactableObject.position;
    }
    void ResetSocketPosition()
    {
        socetInteractor.position = transform.position;
    }

    public Transform GetStarPosition()
    {
        if (interactableObject)
            return interactableObject;
        return socetInteractor;
    }

    public bool GetState()
    {
        if (interactableObject != null)
            return true;
        return false;
    }
}
