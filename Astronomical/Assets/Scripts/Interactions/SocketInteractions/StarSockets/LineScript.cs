using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LineScript : MonoBehaviour
{

    public CustomSocket pos1 = null;

    public CustomSocket pos2 = null;
    public LineRenderer lineRenderer;
    private Color32 startColor;
    private Color32 endColor;
    private Color32 white = new Color32(255, 255, 255, 255);
    private Color32 transparent = new Color32(255, 255, 255, 0);
    public void Update()
    {
        UpdateLineRenderer();
    }

    public void SetPoints(CustomSocket _pos1, CustomSocket _pos2)
    {
        pos1 = _pos1;
        pos2 = _pos2;
        UpdateLineRenderer();
    }

    void UpdatePositions()
    {
        lineRenderer.SetPosition(0, pos1.star.position);
        lineRenderer.SetPosition(1, pos2.star.position);
    }

    void UpdateColors()
    {
        if (pos1.isFilled == false)
        {
            startColor = transparent;
        }
        else
        {
            startColor = white;
        }
        if (pos2.isFilled == false)
        {
            endColor = transparent;
        }
        else
        {
            endColor = white;
        }

        lineRenderer.startColor = startColor;
        lineRenderer.endColor = endColor;
    }

    void UpdateLineRenderer()
    {
        UpdateColors();
        UpdatePositions();
    }

    private void OnDrawGizmos()
    {

        Gizmos.DrawLine(pos1.transform.position, pos2.transform.position);

    }
}
