using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    [SerializeField]
    private CustomSocket pos1 = null;
    [SerializeField]
    private CustomSocket pos2 = null;
    public LineRenderer lineRenderer;

    public void Update()
    {
        UpdatePositions();
    }

    public void SetPoints(CustomSocket _pos1, CustomSocket _pos2)
    {
        pos1 = _pos1;
        pos2 = _pos2;
        UpdatePositions();
    }

    void UpdatePositions()
    {
        lineRenderer.SetPosition(0, pos1.attachTransform.position);
        lineRenderer.SetPosition(1, pos2.attachTransform.position);
    }
}
