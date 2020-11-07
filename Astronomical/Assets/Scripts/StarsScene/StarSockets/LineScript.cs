using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    private Transform origin;
    private Transform destination;
    private Vector3 oldOrigin;
    private Vector3 oldDestination;
    public bool isActive = true;
    LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lineRenderer.enabled = isActive;
        if (origin.position != oldOrigin)
        {
            lineRenderer.SetPosition(0, origin.position);
            oldOrigin = origin.position;
        }
        if (destination.position != oldDestination)
        {
            lineRenderer.SetPosition(1, destination.position);
            oldOrigin = destination.position;
        }
    }

    public void SetPoints(Transform _origin, Transform _destination)
    {
        origin = _origin;
        destination = _destination;
    }
}
