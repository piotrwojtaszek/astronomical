using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    private CustomSocket pos1 = null;
    private CustomSocket pos2 = null;
    public LineRenderer lineRenderer;

    public void UpdateLine()
    {
        lineRenderer.SetPosition(0, pos1.attachTransform.position);
        lineRenderer.SetPosition(1, pos2.attachTransform.position);
    }

    public void SetPoints(CustomSocket _pos1, CustomSocket _pos2)
    {
        pos1 = _pos1;
        pos2 = _pos2;
        UpdateLine();
    }
}
