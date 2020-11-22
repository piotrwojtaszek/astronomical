using UnityEngine;
using System.Collections;
public class Circle : MonoBehaviour
{
    public int segments;
    public float xradius;
    public float yradius;
    LineRenderer line;
    private float multiplier = 1f;
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        multiplier = line.widthMultiplier;
        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        CreatePoints();
    }


    void CreatePoints()
    {
        float x;
        float z;
        float y = 0f;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            line.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / segments);
        }
    }

    private void Update()
    {
        line.widthMultiplier = multiplier * transform.lossyScale.x;
    }
}
