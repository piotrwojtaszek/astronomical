using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScaler : MonoBehaviour
{
    TrailRenderer trailRenderer;
    float widthMultiplier = 1f;
    float segmentsMultiplier = 1f;
    // Start is called before the first frame update
    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        segmentsMultiplier = trailRenderer.minVertexDistance;
        widthMultiplier = trailRenderer.widthMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        trailRenderer.widthMultiplier = widthMultiplier * transform.lossyScale.x;
        trailRenderer.minVertexDistance = segmentsMultiplier * transform.lossyScale.x;
    }
}
