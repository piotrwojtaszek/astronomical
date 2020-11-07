using UnityEngine;

public class StarConnector : MonoBehaviour
{
    public GameObject firstStar;
    public GameObject secondStar;
    LineRenderer lineRenderer;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.SetPosition(0, firstStar.transform.position);

        lineRenderer.SetPosition(1, secondStar.transform.position);

    }
}
