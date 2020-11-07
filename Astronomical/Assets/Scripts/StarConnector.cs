using Boo.Lang;
using UnityEngine;
public class StarConnector : MonoBehaviour
{
    public GameObject[] lines;
    public GameObject linePrefab;
    private List<GameObject> lineRenderers = new List<GameObject>();
    private void Awake()
    {
        foreach (GameObject line in lines)
        {
            GameObject obj = Instantiate(linePrefab);
            lineRenderers.Add(obj);
            obj.GetComponent<LineScript>().SetPoints(GetComponent<StarDropZone>().GetStarPosition(), line.GetComponent<StarDropZone>().GetStarPosition());

        }
    }

    public void SetLineRendererState(bool state)
    {
        foreach (GameObject line in lineRenderers)
        {
            line.GetComponent<LineRenderer>().enabled = state;
        }
    }
}
