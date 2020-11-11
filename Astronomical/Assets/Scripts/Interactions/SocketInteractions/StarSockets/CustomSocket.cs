using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSocket : MonoBehaviour
{
    ObjectsInfo interactable = null;
    [SerializeField]
    Transform socket;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (interactable && !interactable.picked)
        {
            socket.position = interactable.transform.position;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable") && other.GetComponent<ObjectsInfo>())
        {
            interactable = other.GetComponent<ObjectsInfo>();
            socket.position = interactable.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactable = null;
        }
    }
}
